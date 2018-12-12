using AutoMapper;
using Core.DTOs.ActasEU;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<SubCategoria, AddActaEUDetalleViewModel>()
                .ForMember(dest => dest.SubCategoriaId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Categoria, AddActaEUCategoriaViewModel>()
                .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
