using System;
using InjectionInterface;

namespace InjectRepository
{
    public class ComponentInterceptor:IComponentInterceptor
    {
        public bool SaveDb(){
            Console.WriteLine("In SaveDb method ... ");
            return true;
        }
    }
}