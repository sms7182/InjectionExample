using System.Collections.Generic;

namespace InjectionInterface
{
    public interface IRepository
    {
        IEntityModel CreateEntityModel();
        List<IEntityModel> GetAll();
    }
}