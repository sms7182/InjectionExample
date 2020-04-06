using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using InjectionInterface;
using InjectionService;
using InjectRepository;

namespace InjectMiddle{
    public class Installer : IWindsorInstaller
    {
         public void Install(IWindsorContainer container, IConfigurationStore store)
        {
                   
                  container.Install(FromAssembly.Containing<DataInstaller>());

            container.Register(
          // Component.For<IRepository>().ImplementedBy<HandleRepository>().LifestyleTransient());
          // container.Register(
          // Component.For<IHandleService>().ImplementedBy<HandleService>().LifestyleTransient()
          Classes.FromAssembly(typeof(HandleRepository).Assembly).BasedOn(typeof(IRepository))
            .WithService.FromInterface(typeof(IRepository)).LifestyleTransient(),
      
      
          Classes.FromAssembly(typeof(HandleService).Assembly).BasedOn(typeof(IHandleService))
            .WithService.FromInterface(typeof(IHandleService)).LifestyleTransient()
      
            // Classes.FromAssembly(typeof(HandleRepository).Assembly)
            // .Where(it=>it.IsAssignableFrom(typeof(IRepository))).LifestyleTransient(),      
             
            // Classes.FromAssembly(typeof(HandleService).Assembly)
            // .Where(it=>it.IsAssignableFrom( typeof(IHandleService))).LifestyleTransient()
             
          );
        }
    }
}