﻿using BlogSystem.Data.Models.Abstracts;
using System.Linq;

namespace BlogSystem.Data.Repository
{
    public interface IRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
