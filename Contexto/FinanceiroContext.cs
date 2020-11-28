using Financeiro.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.Contexto
{
    public class FinanceiroContext: DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Divida> Divida { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=admin;Initial Catalog=Financeiro;Data Source=DANI");
        }
    }
}
