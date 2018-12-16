using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Categorias
{
    public class UpsertSubCategoriaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Caracter { get; set; }
    }
}
