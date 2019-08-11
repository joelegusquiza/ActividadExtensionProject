using AutoMapper;
using Core.DTOs.Profile;
using Core.DTOs.Usuarios;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
	public class UsuariosProfile : Profile
	{
		public UsuariosProfile()
		{
			CreateMap<Usuario, UsuariosViewModel>()
				.ReverseMap();

			CreateMap<Usuario, UsuariosAddViewModel>()
				.ReverseMap();

			CreateMap<Usuario, UsuariosEditViewModel>()
			    .ReverseMap();

			CreateMap<Usuario, ProfileViewModel>()
				.ReverseMap();
		}
	}
}
