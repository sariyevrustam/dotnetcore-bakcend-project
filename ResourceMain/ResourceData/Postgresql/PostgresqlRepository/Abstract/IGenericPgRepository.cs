
using ResourceData.Postgresql.Models.BaseModelClasses;

namespace ResourceData.Postgresql.PostgresqlRepository.Abstract
{
    public interface IGenericPgRepository<InputClass> where InputClass : class
    {
        ItemResult Get(int id);
        ItemResult GetAll();
        ItemResult Add(InputClass newItem);
        ItemResult Delete(int resourceId, int deletedBy);
        ItemResult Edit(int resourceId, int updatedBy, InputClass editedResource);
    }
}
