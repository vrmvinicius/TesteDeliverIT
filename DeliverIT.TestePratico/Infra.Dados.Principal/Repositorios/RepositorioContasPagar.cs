using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Repositorios;
using Infra.Dados.Principal.DbContexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dados.Principal.Repositorios
{
    public class RepositorioContasPagar : RepositorioBase<ContasPagar>, IRepositorioContasPagar
    {
        private readonly DbContextTeste _dbContexto;

        public RepositorioContasPagar(DbContextTeste dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public override async Task<List<ContasPagar>> GetAllAsync()
        {
            return await _dbContexto.ContasPagar.Include(x => x.ContasPagarBaixa)
                                                .AsNoTracking()
                                                .ToListAsync();            
        }

        public override async Task<bool> ExistsAsync(int id)
        {
            return await _dbContexto.ContasPagar.AnyAsync(x => x.Id == id);
        }
    }
}
