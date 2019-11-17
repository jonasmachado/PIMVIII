using AutoMapper;
using BpeCentral.Dominio;
using BpeCentral.Web.ViewModels;

namespace BpeCentral.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BPE_USUARIOS, UsuarioViewModel>();
            CreateMap<BPE_CLIENTE, ClienteViewModel>().ForMember(x => x.BPE_LOG_CLIENTE, opt => opt.Ignore())
                                                      .ForMember(x => x.BPE_SERIE_BILHETE, opt => opt.Ignore())
                                                      .ForMember(x => x.TIPO_CLIENTE_STR, opt => opt.Ignore());

            CreateMap<BPE_CONTROLE_SERIE, ControleSerieViewModel>();

            CreateMap<BPE_SERIE_BILHETE, SerieBilheteViewModel>();

            CreateMap<BPE_CONFIGURACAO_EMITENTE, ConfiguracaoEmitenteViewModel>().ForMember(x => x.BPE_SERIE_BILHETE, opt => opt.Ignore())
                                                                                 .ForMember(x => x.BPE_BPES, opt => opt.Ignore())
                                                                                 .ForMember(x => x.BPE_CONTROLE_SERIE, opt => opt.Ignore());
        }
    }
}