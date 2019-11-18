﻿using AutoMapper;
using MyPOS.Dominio.DTOS;
using MyPOS.Dominio.Entidades;

namespace MyPOS.Dominio.Mappers
{
    class EntidadeParaDTO : Profile
    {
        public EntidadeParaDTO()
        {
            CreateMap<Usuario, DTOUsuario>();
        }
    }
}