using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using InjectionApp;

namespace InjectionWeb
{
  public class RawRequestBodyFormatter : InputFormatter
    {
        public RawRequestBodyFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
        }


        /// <summary>
        /// Allow text/plain, application/octet-stream and no content type to
        /// be processed
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Boolean CanRead(InputFormatterContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var contentType = context.HttpContext.Request.ContentType;
            if (string.IsNullOrEmpty(contentType) || contentType == "text/plain" ||
                contentType == "application/octet-stream")
                return true;

            return false;
        }

        /// <summary>
        /// Handle text/plain or no content type for string results
        /// Handle application/octet-stream for byte[] results
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            var contentType = context.HttpContext.Request.ContentType;


            if (string.IsNullOrEmpty(contentType) || contentType == "text/plain")
            {
                using (var reader = new StreamReader(request.Body))
                {
                    var content = await reader.ReadToEndAsync();
                    return await InputFormatterResult.SuccessAsync(content);
                }
            }
            if (contentType == "application/octet-stream")
            {
                using (var ms = new MemoryStream(2048))
                {
                    await request.Body.CopyToAsync(ms);
                    var content = ms.ToArray();
                    return await InputFormatterResult.SuccessAsync(content);
                }
            }

            return await InputFormatterResult.FailureAsync();
        }
    }
    public class TextPlainInputFormatter : TextInputFormatter
    {
        public TextPlainInputFormatter()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(UTF8EncodingWithoutBOM);
            SupportedEncodings.Add(UTF16EncodingLittleEndian);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context,
            Encoding encoding)
        {
            string data = null;
            using (var streamReader = context.ReaderFactory(
                context.HttpContext.Request.Body,
                encoding))
            {
                data = await streamReader.ReadToEndAsync();
            }

            return InputFormatterResult.Success(data);
        }


    }
    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
        
        
            services.AddSpaStaticFiles(configuration=>{
                configuration.RootPath="src/dist";
            });
            
            
            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            
        
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                  o.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));
//              services.AddMvc().AddApplicationPart(typeof(ApplicationController).Assembly).AddControllersAsServices();

            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new TextPlainInputFormatter());
            });
     
            // services.Configure<ApiBehaviorOptions>(options =>
            //     {
            //       options.SuppressConsumesConstraintForFormFileParameters = true;
            //       options.SuppressInferBindingSourcesForParameters = true;
            //       options.SuppressModelStateInvalidFilter = true;
            //     });
            services.AddControllers(options => options.EnableEndpointRouting = false).AddNewtonsoftJson();
           return  services.AddCustomisedSignalR();
        }
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=WeatherForecast}/{action=Get}/{id?}");

            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCookiePolicy();
           

            app.UseMvc();
             app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "src";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
               // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            });
        }
    
    }
}
