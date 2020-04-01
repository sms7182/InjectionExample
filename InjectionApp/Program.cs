using Castle.Windsor;
using Castle.Windsor.Installer;
using InjectionInterface;
using InjectMiddle;

namespace InjectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
         var container= new WindsorContainer();         
          container.Install(FromAssembly.Containing<Installer>());
            
        //   container.Register(Component.For<IRepository>().ImplementedBy<HandleRepository>());
        //  container.Register(Component.For<IHandleService>().ImplementedBy<HandleService>());
         var root=container.Resolve<IHandleService>();
         root.PrintAll();

        }
    }
}
