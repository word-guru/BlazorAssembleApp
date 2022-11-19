using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.WebApi.Date;
using MyShop.WebApi.GenericRepository.InterfaceGenericRepozitory;

namespace MyShop.WebApi.GenericRepository;

public class EfRepository<TEntity> : IGRepository<TEntity> where TEntity : class,IEntity
{
    protected readonly AppDbContext _dbContext;
    private DbSet<TEntity> Entities => _dbContext.Set<TEntity>();

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual Task<TEntity> GetById(Guid id)
        => Entities.FirstAsync(it => it.Id == id);

    public virtual async Task<IReadOnlyList<TEntity>> GetAll()
        => await Entities.ToListAsync();

    public virtual async Task Add(TEntity entity)
    {
        await Entities.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var product = await Entities
            .FirstAsync(p => p.Id == id);
        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}