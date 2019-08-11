using ApplicationContext;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Profile;
using Core.DTOs.Shared;
using Core.DTOs.Usuarios;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Services
{
	public class UsuariosService : IUsuarios
	{
		private readonly DataContext _context;

		public UsuariosService(DataContext context)
		{
			_context = context;
		}

		public List<Usuario> GetAll()
		{
			return _context.Set<Usuario>().Where(x => x.Active).ToList();
		}

		public Usuario GetById(int id)
		{
			return GetAll().FirstOrDefault(x => x.Id == id);
		}

		public Usuario GetForLogin(string email)
		{
			var usuario = _context.Set<Usuario>().FirstOrDefault(x => x.Active && x.Email == email);
			return usuario;
		}

		public SystemValidationModel Add(UsuariosAddViewModel viewModel)
		{
			var usuario = Mapper.Map<Usuario>(viewModel);
			usuario.SetPassword(viewModel.Password);
			_context.Entry(usuario).State = EntityState.Added;
			var success = _context.SaveChanges() > 0;
			var validation = new SystemValidationModel()
			{
				Success = success,
				Id = usuario.Id
			};
			return validation;
		}
		public SystemValidationModel Edit(UsuariosEditViewModel viewModel)
		{
			var usuario = GetById(viewModel.Id);
			if (!string.IsNullOrEmpty(viewModel.Password))
				usuario.SetPassword(viewModel.Password);
			usuario = Mapper.Map(viewModel, usuario);
			_context.Entry(usuario).State = EntityState.Modified;
			var success = _context.SaveChanges() > 0;
			var validation = new SystemValidationModel()
			{
				Success = success,
				Message = success ? "Se ha editado correctamente el usuario" : "No se pudo editar el usuario"
			};
			return validation;
		}

		public SystemValidationModel Edit(ProfileViewModel viewModel)
		{
			var usuario = GetById(viewModel.Id);
			usuario = Mapper.Map(viewModel, usuario);
			if (!string.IsNullOrEmpty(viewModel.Password))
			{
				usuario.SetPassword(viewModel.Password);
			}
			_context.Entry(usuario).State = EntityState.Modified;
			var success = _context.SaveChanges() > 0;
			var validation = new SystemValidationModel()
			{
				Id = usuario.Id,
				Message = success ? "Se ha editado correctamente el usuario" : "No se pudo editar el usuario",
				Success = success
			};
			return validation;
		}
	}
}
