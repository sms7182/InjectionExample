using System;
using InjectionEx;
namespace InjectionService
{
    public class HandleService:IHandleService
    {
      public void Print(EntityModel el){
        if(el!=null){
          Console.Write("EntityModel is {0}",el.Name);
        }
        else{
          Console.Write("Entitymdoel is null");
        }

      }
    }
}
