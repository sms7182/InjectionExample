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
            throw new NotImplementedException();
        }
    }
}