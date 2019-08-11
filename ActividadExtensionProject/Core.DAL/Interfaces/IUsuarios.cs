using Core.DTOs.Profile;
using Core.DTOs.Shared;
using Core.DTOs.Usuarios;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Interfaces
{
	public interface IUsuarios
	{
		List<Usuario> GetAll();
		Usuario GetById(int id);
		Usuario GetForLogin(string email);
		SystemValidationModel Add(UsuariosAddViewModel viewModel);
		SystemValidationModel Edit(UsuariosEditViewModel viewModel);
		SystemValidationModel Edit(ProfileViewModel viewModel);

	}
}
