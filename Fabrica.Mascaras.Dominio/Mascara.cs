using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Mascaras.Dominio
{
    public class Mascara
    {
        public long IdMascara { get; set; }
        public string NomeMascara { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public virtual Tecido Tecido { get; set; }
        public int IdTecido { get; set; }
        public int Ano { get; set; }
    }
}
