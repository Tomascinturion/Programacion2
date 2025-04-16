using CDatos.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace CDatos.Repositorios
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected VeterinariaContext _context { get; set; }

        public Repository(VeterinariaContext context)
        {
            this._context = context;
        }

        public IEnumerable<T> FindAll()
        {
            return this._context.Set<T>().ToList();
        }


        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this._context.Set<T>().Where(expression).ToListAsync();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
