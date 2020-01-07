using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using InjectionEx;
using InjectionService;
using InjectRepository;
namespace InjectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
         var container= new WindsorContainer();
          container.Register(Component.For<IRepository>().ImplementedBy<HandleRepository>());
         container.Register(Component.For<IHandleService>().ImplementedBy<HandleService>());
         var root=container.Resolve<IHandleService>();
        root.Print();

        }
    }
}
