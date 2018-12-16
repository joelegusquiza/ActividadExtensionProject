using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Categorias
{
    public class AddCategoriaViewModel
    {
        public string Nombre { get; set; }
        public string Caracter { get; set; }
        public string Descripcion { get; set; }
        public int HoraReloj { get; set; }
        public int HoraExtension { get; set; }

        public UpsertSubCategoriaViewModel SubCategoria { get; set; } = new UpsertSubCategoriaViewModel();
        public List<UpsertSubCategoriaViewModel> SubCategorias { get; set; } = new List<UpsertSubCategoriaViewModel>();
    }

  
}
