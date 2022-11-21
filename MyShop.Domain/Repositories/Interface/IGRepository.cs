using MyShop.Models;

namespace MyShop.Domain.Repositories.Interface;

public interface IGRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> GetById(Guid id);
    Task<IReadOnlyList<TEntity>> GetAll();
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task DeleteById(Guid id);
}