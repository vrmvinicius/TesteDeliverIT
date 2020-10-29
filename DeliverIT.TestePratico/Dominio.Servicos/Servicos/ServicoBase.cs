using Dominio.Principal.Interfaces.Repositorios;
using Dominio.Principal.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos.Base
{
    public abstract class ServicoBase<TEntidade> : IDisposable, IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> _repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task AddAsync(TEntidade obj)
        {
            await _repositorio.AddAsync(obj);
        }
        public async Task<List<TEntidade>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }
        public async Task<TEntidade> GetByIdAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }
        public async Task RemoveAsync(TEntidade obj)
        {
            await _repositorio.RemoveAsync(obj);
        }
        public async Task UpdateAsync(TEntidade obj)
        {
            await _repositorio.UpdateAsync(obj);
        }                
        public async Task<bool> ExistsAsync(int id)
        {
            return await _repositorio.ExistsAsync(id);
        }
        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
