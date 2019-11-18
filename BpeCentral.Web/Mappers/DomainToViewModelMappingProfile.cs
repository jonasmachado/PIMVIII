using AutoMapper;
using BpeCentral.Dominio;
using BpeCentral.Web.ViewModels;
using MyPOS.Dominio.Entidades;

namespace BpeCentral.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();          
        }
    }
}