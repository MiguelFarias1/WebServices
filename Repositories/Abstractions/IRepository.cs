﻿namespace APICatalogo.Repositories.Abstractions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Save(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
}
