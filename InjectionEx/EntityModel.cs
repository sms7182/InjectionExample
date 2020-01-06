using System;
namespace InjectionEx
{
    public class EntityModel
    {
        public EntityModel()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}