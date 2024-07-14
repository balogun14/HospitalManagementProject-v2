namespace HospitalManagementProject.Repositories.Contracts;

public interface IBaseRepo<TEntity , in TCreateEntity, in TEditEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(TCreateEntity createEntity);
    Task<bool> UpdateAsync(TEditEntity editEntity);
    Task<bool> DeleteAsync(Guid id);
}