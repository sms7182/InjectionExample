using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using InjectionEx;
using InjectionService;
namespace InjectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
         var container= new WindsorContainer();
         container.Register(Component.For<IHandleService>().ImplementedBy<HandleService>());
         var root=container.Resolve<IHandleService>();
         var x=new EntityModel();
         x.Name="djhjhjhf";
         root.Print(x);

        }
    }
}
