using InjectionEx;
using System;
namespace InjectRepository
{
    public class HandleRepository : IRepository
    {
        public EntityModel CreateEntityModel()
        {
            return new EntityModel(){
                Id=Guid.NewGuid(),
                Name="Test"
            };
        }
    }
}