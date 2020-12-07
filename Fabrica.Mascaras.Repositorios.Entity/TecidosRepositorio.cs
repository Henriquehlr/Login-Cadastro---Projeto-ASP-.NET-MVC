using Fabrica.Mascaras.Dados.Entity.Context;
using Fabrica.Mascaras.Dominio;
using Fabrica.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Fabrica.Mascaras.Repositorios.Entity
{
    public class TecidosRepositorio : RepositorioGenericoEntity<Tecido, int>
    {
        public TecidosRepositorio(MascaraDbContext contexto) : base(contexto)
        {

        }

        public override List<Tecido> Selecionar()
        {
            return _contexto.Set<Tecido>().Include(p => p.Mascaras).ToList();
        }

        public override Tecido SelecionarPorId(int id)
        {
            return _contexto.Set<Tecido>().Include(p => p.Mascaras)
                            .SingleOrDefault(t => t.Id == id);
        }
    }
}
