using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Extensions.DependencyInjection;
using System;
using Castle.Facilities.AspNetCore;
using InjectMiddle;

namespace InjectionApp
{

    public static class IServiceCollectionExtensions{
      public static IServiceProvider AddCustomisedSignalR(this IServiceCollection services)
         {
    
                  var container= WebConfiguration.Register();
                  return WindsorRegistrationExtensions.AddWindsor(services,container);
  
         }
   }

    public static class WebConfiguration
    {
         private static IWindsorContainer container;
         public static  IWindsorContainer Register(){
                  container = new WindsorContainer();
                  container.Install(FromAssembly.Containing<Installer>());
            
                  container.Install(FromAssembly.Instance(typeof(WebConfiguration).Assembly));
          
                  return container;
         }
    }
}