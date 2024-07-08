using Comex.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Data
{
    public class Database : DbContext
    {
        string conexaoBd;
        public DbSet<Produto> Produtos { get; set; }

        public Database(string conexao)
        {
            conexaoBd = conexao;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(conexaoBd);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
