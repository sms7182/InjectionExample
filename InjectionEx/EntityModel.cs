using System;
using InjectionInterface;

namespace InjectionEx
{
    public class EntityModel:IEntityModel
    {
        public EntityModel()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}