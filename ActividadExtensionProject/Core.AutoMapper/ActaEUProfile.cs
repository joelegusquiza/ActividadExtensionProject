using AutoMapper;
using Core.Entities;
using Core.DTOs.ActasEU;

namespace Core.AutoMapper
{
    public class ActaEUProfile : Profile
    {
        public ActaEUProfile()
        {           
            CreateMap<ActaEU, ActaEUViewModel>()
                .ForMember(dest => dest.Estudiante, opt => opt.MapFrom(src => $"{src.Estudiante.Nombre} {src.Estudiante.Apellido}"))
                .ForMember(dest => dest.Carrera, opt => opt.MapFrom(src => $"{src.Carrera.Abreviatura}"));

            CreateMap<AddActaEUDetalleViewModel, ActaEUDetalle>();
              
        }
    }
}
