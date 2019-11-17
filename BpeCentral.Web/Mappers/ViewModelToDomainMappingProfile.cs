using AutoMapper;
using BpeCentral.Dominio;
using BpeCentral.Web.ViewModels;

namespace BpeCentral.Web.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, BPE_USUARIOS>();
            CreateMap<ClienteViewModel, BPE_CLIENTE>().ForMember(x => x.BPE_LOG_CLIENTE, opt => opt.Ignore())
                                                     .ForMember(x => x.BPE_SERIE_BILHETE, opt => opt.Ignore());

            CreateMap<ControleSerieViewModel, BPE_CONTROLE_SERIE>().ForMember(x => x.BPE_CONFIGURACAO_EMITENTE, opt => opt.Ignore())
                                                                   .ForMember(x => x.BPE_TIPO_APLICACAO, opt => opt.Ignore());

            CreateMap<SerieBilheteViewModel, BPE_SERIE_BILHETE>().ForMember(x => x.BPE_CLIENTE, opt => opt.Ignore())
                                                                 .ForMember(x => x.BPE_CONFIGURACAO_EMITENTE, opt => opt.Ignore())
                                                                 .ForMember(x => x.BPE_TIPO_APLICACAO, opt => opt.Ignore());

            CreateMap<ConfiguracaoEmitenteViewModel, BPE_CONFIGURACAO_EMITENTE>().ForMember(x => x.BPE_SERIE_BILHETE, opt => opt.Ignore())
                                                                                 .ForMember(x => x.BPE_BPES, opt => opt.Ignore())
                                                                                 .ForMember(x => x.BPE_CONTROLE_SERIE, opt => opt.Ignore());
        }
    }
}