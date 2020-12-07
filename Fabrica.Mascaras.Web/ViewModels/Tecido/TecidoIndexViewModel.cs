using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fabrica.Mascaras.Web.ViewModels.Tecido
{
    public class TecidoIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Tipo do Tecido")]
        public string Tipo { get; set; }

        [Display(Name = "Composição do Tecido")]
        public string Composicao { get; set; }

        [Display(Name = "Característica do Tecido")]
        public string Caracteristica { get; set; }

        [Display(Name = "Nome do Fornecedor")]
        public string Fornecedor { get; set; }

        [Display(Name = "Email do Fornecedor")]
        public string Email { get; set; }
    }
}