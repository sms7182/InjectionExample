using InjectionEx;
using InjectionInterface;
using System;
using System.Collections.Generic;

namespace InjectRepository
{
    public class HandleRepository : IRepository
    {
        public IEntityModel CreateEntityModel()
        {
            return new EntityModel(){
                Id=Guid.NewGuid(),
                Name="Test"
            };
        }

        public List<IEntityModel> GetAll()
        {
            return new List<IEntityModel>{
                new EntityModel(){
                Id=Guid.NewGuid(),
                Name="Test01"
            },
                new EntityModel(){
                Id=Guid.NewGuid(),
                Name="Test02"
            }
            };
        }
    }
}