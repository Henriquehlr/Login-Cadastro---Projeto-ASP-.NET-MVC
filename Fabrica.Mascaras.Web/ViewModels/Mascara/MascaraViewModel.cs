using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fabrica.Mascaras.Web.ViewModels.Mascara
{
    public class MascaraViewModel
    {
        [Required(ErrorMessage = "Id Obrigatório")]
        public long IdMascara { get; set; }

        [Required(ErrorMessage = "Nome da Mascara Obrigatório")]
        [Display(Name = "Nome da Mascara")]
        public string NomeMascara { get; set; }

        [Required(ErrorMessage = "Cor da Mascara Obrigatório")]
        [Display(Name = "Cor da Mascara")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Tamanho da Mascara Obrigatório")]
        [Display(Name = "Tamanho da Mascara")]
        public string Tamanho { get; set; }

        [Required(ErrorMessage = "Selecione o Tipo de Tecido")]
        [Display(Name = "Tipo de Tecido")]
        public int IdTecido { get; set; }

        [Required(ErrorMessage = "Coloque o Ano de Fabricação")]
        [Display(Name = "Ano de Fabricação")]
        public int Ano { get; set; }
    }
}