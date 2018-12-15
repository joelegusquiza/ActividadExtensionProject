using AutoMapper;
using Core.DTOs.Estudiantes;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
    public class EstudianteProfile : Profile
    {
        public EstudianteProfile()
        {
            CreateMap<Estudiante, EstudianteViewModel>()
                .ForMember(dest => dest.Carrera, opt => opt.MapFrom(src => src.Carrera.Nombre))
                .ReverseMap();

            CreateMap<Estudiante, UpsertEstudianteViewModel>()                
                 .ReverseMap();
        }
    }
}
