﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.Core
{
    public interface IDataRepository
    {
    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, IIdentifiableEntity, new()
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
    }
}
