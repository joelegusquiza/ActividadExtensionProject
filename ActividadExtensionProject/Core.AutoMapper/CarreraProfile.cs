using AutoMapper;
using Core.DTOs.Carreras;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
    public class CarreraProfile : Profile
    {
        public CarreraProfile()
        {
            CreateMap<Carrera, CarreraViewModel>()
                .ReverseMap();

            CreateMap<Carrera, UpsertCarreraViewModel>()
                 .ReverseMap();
        }
    }
}
