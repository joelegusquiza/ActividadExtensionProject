﻿using Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.ActasEU
{
    public class AddActaEUViewModel
    {
        public string CedulaIdentidad { get; set; }
        public int CarreraSeleccionadaId { get; set; }
        public List<DropDownViewModel<int>> CarrerasExistentes { get; set; } = new List<DropDownViewModel<int>>();
        public List<AddActaEUCategoriaViewModel> Categorias { get; set; } = new List<AddActaEUCategoriaViewModel>();
    }

    public class AddActaEUCategoriaViewModel
    {
        public int CategoriaId { get; set; }
        public string Caracter { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int HorasReloj { get; set; }
        public int HorasExtension { get; set; }
        public List<AddActaEUDetalleViewModel> Detalle { get; set; } = new List<AddActaEUDetalleViewModel>();
    }

    public class AddActaEUDetalleViewModel
    {
        public int SubCategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Caracter { get; set; }  
        public int HorasRelojRealizadas { get; set; }
        public int HorasExtensionRealizadas { get; set; }
        public DateTimeOffset FechaInicio { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset FechaFin { get; set; } = DateTimeOffset.Now;
        public string LugarProfesorTutor { get; set; }
		public int BeneficiariosHombres { get; set; }
		public int BeneficiariosMujeres { get; set; }

	}
}
