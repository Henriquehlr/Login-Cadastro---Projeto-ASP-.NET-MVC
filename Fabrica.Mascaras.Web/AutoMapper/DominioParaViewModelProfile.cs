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
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Tecido, TecidoIndexViewModel>()
                .ForMember(p => p.Tipo, opt =>
                {
                    opt.MapFrom(src =>
                    string.Format("{0}, {1}", src.Tipo, src.Fornecedor.ToString())
                    );
                });
            Mapper.CreateMap<Tecido, TecidoIndexViewModel>();

            Mapper.CreateMap<Mascara, MascaraIndexViewModels>()
                .ForMember(p => p.NomeTecido, opt =>
                {
                    opt.MapFrom(src =>
                        src.Tecido.Tipo
                        );
                });

            Mapper.CreateMap<Mascara, MascaraViewModel>();
        }
    }
}