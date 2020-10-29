using Dominio.Principal.Interfaces.Repositorios;
using Infra.Dados.Principal.DbContexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dados.Principal.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade> where TEntidade : class
    {
        private readonly DbContextTeste _dbContexto;

        public RepositorioBase(DbContextTeste Context)
        {
            _dbContexto = Context;
        }

        public virtual async Task AddAsync(TEntidade obj)
        {
            try
            {
                await _dbContexto.Set<TEntidade>().AddAsync(obj);
                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<TEntidade> GetByIdAsync(int id)
        {
            return await _dbContexto.Set<TEntidade>().FindAsync(id);
        }
        public virtual async Task<List<TEntidade>> GetAllAsync()
        {
            return await _dbContexto.Set<TEntidade>().AsNoTracking().ToListAsync();
        }
        public virtual async Task UpdateAsync(TEntidade obj)
        {
            try
            {
                if (_dbContexto.Entry(obj).State == EntityState.Detached)
                {
                    _dbContexto.Attach(obj);
                    _dbContexto.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    _dbContexto.Update(obj);
                }

                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual async Task RemoveAsync(TEntidade obj)
        {
            try
            {
                _dbContexto.Set<TEntidade>().Remove(obj);
                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Dispose()
        {
            _dbContexto.Dispose();
        }
                
        public abstract Task<bool> ExistsAsync(int id);
    }
}
