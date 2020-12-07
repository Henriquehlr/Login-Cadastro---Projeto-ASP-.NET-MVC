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
    public class MascarasRepositorio : RepositorioGenericoEntity<Mascara, long>
    {
        public MascarasRepositorio(MascaraDbContext contexto) : base(contexto)
        {

        }

        public override List<Mascara> Selecionar()
        {
            return _contexto.Set<Mascara>().Include(p => p.Tecido).ToList();
        }

        public override Mascara SelecionarPorId(long id)
        {
            return _contexto.Set<Mascara>().Include(p => p.Tecido)
                .SingleOrDefault(m => m.IdMascara == id);
        }
    }
}
