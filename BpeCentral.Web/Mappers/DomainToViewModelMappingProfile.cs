using AutoMapper;
using HomeworkBuddy.Dominio;
using HomeworkBuddy.Web.ViewModels;
using MyPOS.Dominio.Entidades;

namespace HomeworkBuddy.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();          
            CreateMap<Trabalho, TrabalhoViewModel>();          
        }
    }
}