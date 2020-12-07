using AutoMapper;
using Fabrica.Mascaras.Dominio;
using Fabrica.Mascaras.Web.ViewModels.Mascara;
using Fabrica.Mascaras.Web.ViewModels.Tecido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fabrica.Mascaras.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TecidoViewModel, Tecido>();
            Mapper.CreateMap<MascaraViewModel, Mascara>();
        }
    }
}