﻿using MyShop.Models;

namespace MyShop.WebApi.GenericRepository.InterfaceGenericRepozitory;

public interface IGRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> GetById(Guid id);
    Task<IReadOnlyList<TEntity>> GetAll();
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task DeleteById(Guid id);
}