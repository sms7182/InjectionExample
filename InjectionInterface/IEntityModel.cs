using System;
namespace InjectionInterface
{
    public interface IEntityModel
    {               
        Guid Id { get; set; }
        string Name { get; set; }

    }
}