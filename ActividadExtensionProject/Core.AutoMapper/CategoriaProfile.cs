using AutoMapper;
using Core.DTOs.ActasEU;
using Core.DTOs.Categorias;
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
                .ForMember(dest => dest.SubCategoriaId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Categoria, AddActaEUCategoriaViewModel>()
                .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Categoria, CategoriaViewModel>()              
               .ReverseMap();

            CreateMap<Categoria, AddCategoriaViewModel>();

            CreateMap<AddCategoriaViewModel, Categoria>()
                 .ForMember(dest => dest.SubCategorias, opt => opt.Ignore());

            CreateMap<Categoria, EditCategoriaViewModel>();

            CreateMap<EditCategoriaViewModel, Categoria>()
                .ForMember(dest => dest.SubCategorias, opt => opt.Ignore());

            CreateMap<UpsertSubCategoriaViewModel, SubCategoria>()
               .ReverseMap();
        }
    }
}
