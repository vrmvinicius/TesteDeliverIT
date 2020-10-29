using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Principal.Interfaces.Servicos
{
    public interface IServicoBase<TEntidade> where TEntidade : class
    {        
        Task AddAsync(TEntidade obj);
        Task<TEntidade> GetByIdAsync(int id);
        Task<List<TEntidade>> GetAllAsync();
        Task UpdateAsync(TEntidade obj);
        Task RemoveAsync(TEntidade obj);
        Task<bool> ExistsAsync(int id);
        void Dispose();
    }
}
