using IInterceptor = Castle.DynamicProxy.IInterceptor;
using Castle.DynamicProxy;
using System.Reflection;
using System;

namespace InjectRepository
{
    public class NhUnitOfWorkInterceptor : IInterceptor
    {

        /// <summary>
        /// Intercepts a method.
        /// </summary>
        /// <param name="invocation">Method invocation arguments</param>
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("In Interceptor ... ");
            invocation.Proceed();
        }


    }
}