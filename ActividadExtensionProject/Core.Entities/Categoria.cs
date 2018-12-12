using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("Categorias")]
    public class Categoria : BaseEntity
    {
        public string Nombre { get; set; }
        public string Caracter { get; set; }
        public string Descripcion { get; set; }
        public int HoraReloj { get; set; }
        public int HoraExtension { get; set; }

        public ICollection<SubCategoria> SubCategorias { get; set; } = new HashSet<SubCategoria>();
        public ICollection<ActaEUDetalle> ActaEUDetalle { get; set; } = new HashSet<ActaEUDetalle>();
    }
}
