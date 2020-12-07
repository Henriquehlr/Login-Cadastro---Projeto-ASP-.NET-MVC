using Fabrica.Mascaras.Dados.Entity.TypeConfiguration;
using Fabrica.Mascaras.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Mascaras.Dados.Entity.Context
{
    public class MascaraDbContext : DbContext
    {
        public DbSet<Tecido> Tecidos { get; set; }
        public DbSet<Mascara> Mascaras { get; set; }

        public MascaraDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TecidoTypeConfiguration());
            modelBuilder.Configurations.Add(new MascaraTypeConfiguration());
        }
    }
}
