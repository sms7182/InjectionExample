
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Reflection;
using Castle.Core;
using InjectRepository;
using System;
using InjectionInterface;

namespace InjectRepository
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer windsorContainer, IConfigurationStore configurationStore)
        {
            windsorContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;

            windsorContainer.Register(
              
                Component.For<IComponentInterceptor>().ImplementedBy<ComponentInterceptor>().LifestyleTransient()
                .Interceptors(InterceptorReference.ForType<NhUnitOfWorkInterceptor>()).Last,
                Component.For<NhUnitOfWorkInterceptor>()

            );

        }
        void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            Console.WriteLine("In ComponentRegistered ... ");
        }
    }
}
