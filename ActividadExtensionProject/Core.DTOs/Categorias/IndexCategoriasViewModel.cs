using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Categorias
{
    public class IndexCategoriasViewModel
    {
        public List<CategoriaViewModel> Categorias { get; set; } = new List<CategoriaViewModel>();
    }

    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Caracter { get; set; }
        public int HoraReloj { get; set; }
        public int HoraExtension { get; set; }
    }
}
