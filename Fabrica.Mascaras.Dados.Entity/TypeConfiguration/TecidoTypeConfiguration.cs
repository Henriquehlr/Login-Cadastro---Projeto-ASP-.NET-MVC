using Fabrica.Mascaras.Dominio;
using Fabrica.Mascaras.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Mascaras.Dados.Entity.TypeConfiguration
{
    class TecidoTypeConfiguration : FabricaEntityAbstractConfig<Tecido>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Tipo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Tipo");

            Property(p => p.Composicao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Composicao");

            Property(p => p.Composicao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Composicao");

            Property(p => p.Caracteristica)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Caracteristica");

            Property(p => p.Fornecedor)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Fornecedor");

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email");                     
            
            
        }

        protected override void ConfigurarChaveEstrangeira()
        {
            
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Tecido");
        }
    }
}
