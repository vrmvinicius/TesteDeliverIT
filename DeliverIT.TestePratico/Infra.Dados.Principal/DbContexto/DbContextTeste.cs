using Dominio.Principal.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Dados.Principal.DbContexto
{
    public class DbContextTeste : DbContext
    {
        public DbSet<ContasPagar> ContasPagar { get; set; }
        public DbSet<ContasPagarBaixa> ContasPagarBaixas { get; set; }
        
        public DbContextTeste(DbContextOptions<DbContextTeste> options) : base(options)
        {
        }
    }
}
