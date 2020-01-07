using System;
using InjectionEx;
namespace InjectionService
{
    public class HandleService:IHandleService
    {
      IRepository repository;
      public HandleService(IRepository _repository)
      {
          repository=_repository;
      }
      public void Print(){
        var entity=repository.CreateEntityModel();
        Console.Write(string.Concat(string.Format("Name is {0} and Id is {1}",entity.Name,entity.Id )));
      }
    }
}
