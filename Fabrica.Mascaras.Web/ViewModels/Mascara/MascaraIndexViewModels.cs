using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fabrica.Mascaras.Web.ViewModels.Mascara
{
    public class MascaraIndexViewModels
    {
        public long IdMascara { get; set; }

        [Display(Name = "Nome da Mascara")]
        public string NomeMascara { get; set; }

        [Display(Name = "Cor da Mascara")]
        public string Cor { get; set; }

        [Display(Name = "Tamanho da Mascara")]
        public string Tamanho { get; set; }

        [Display(Name = "Nome do Tecido")]
        public string NomeTecido { get; set; }

        [Display(Name = "Ano de Fabricação")]
        public int Ano { get; set; }
    }
}