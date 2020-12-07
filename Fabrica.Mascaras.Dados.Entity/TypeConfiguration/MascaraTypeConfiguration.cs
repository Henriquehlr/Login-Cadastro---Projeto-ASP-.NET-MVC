using Fabrica.Mascaras.Dominio;
using Fabrica.Mascaras.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fabrica.Mascaras.Dados.Entity.TypeConfiguration
{
    class MascaraTypeConfiguration : FabricaEntityAbstractConfig<Mascara>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdMascara)
                .HasColumnName("IdMascara")
                .HasDatabaseGeneratedOption(System.ComponentModel
                                            .DataAnnotations.Schema
                                            .DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.NomeMascara)
                .HasColumnName("NomeMascara")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Cor)
                .HasColumnName("Cor")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Tamanho)
                .HasColumnName("Tamanho")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.IdTecido)
                .HasColumnName("IdTecido")
                .IsRequired();

            Property(p => p.Ano)
                .IsRequired()
                .HasColumnName("Ano");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Tecido)
                .WithMany(p => p.Mascaras)
                .HasForeignKey(fk => fk.IdTecido);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.IdMascara);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Mascara");
        }
    }
}
