﻿

using Dominio.Entidades.Root;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;


namespace Infra.Repositorio;

public class Repositorio<T> : IRepositorio<T> where T : AggregateRoot
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repositorio(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}