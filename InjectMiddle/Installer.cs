using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InjectionInterface;
using InjectionService;
using InjectRepository;

namespace InjectMiddle{
    public class Installer : IWindsorInstaller
    {
         public void Install(IWindsorContainer container, IConfigurationStore store)
        {
                   
            container.Register(
          
            Classes.FromAssembly(typeof(HandleRepository).Assembly)
            .Where(it=>it.IsAssignableFrom(typeof(IRepository))).LifestyleTransient(),      
             
            Classes.FromAssembly(typeof(HandleService).Assembly)
            .Where(it=>it.IsAssignableFrom( typeof(IHandleService))).LifestyleTransient()
             
          );
        }
    }
}