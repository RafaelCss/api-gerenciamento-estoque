﻿using Dominio.Entidades.Base;
using Infra.EF.Context;
using Infra.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class ContextoLeitura<T> : IContextoLeitura<T> where T : Entidade
{
    private readonly DbSet<T> _dbSet;

    public ContextoLeitura(AppContexto context)
    {
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsNoTracking();
    }
}
