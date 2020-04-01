using System;
using InjectionInterface;

namespace InjectionService
{
    public class HandleService:IHandleService
    {
      IRepository repository;
      public HandleService(IRepository _repository)
      {
          repository=_repository;
      }
      public void Print(IEntityModel model){
        var entity=repository.CreateEntityModel();
        Console.Write(string.Concat(string.Format("Name is {0} and Id is {1}",model.Name,model.Id )));
      }

      public void PrintAll(){
        var list=repository.GetAll();
        foreach (var model in list)
        {            
          Console.WriteLine(string.Concat(string.Format("Name is {0} and Id is {1}",model.Name,model.Id )));
        }
      }
    }
}
