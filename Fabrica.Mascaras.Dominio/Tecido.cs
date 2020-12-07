using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Mascaras.Dominio
{
    public class Tecido
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Composicao { get; set; }
        public string Caracteristica { get; set; }
        public string Fornecedor { get; set; }
        public string Email { get; set; }
        public virtual List<Mascara> Mascaras { get; set; }

    }
}
