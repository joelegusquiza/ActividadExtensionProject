using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("SubCategorias")]
    public class SubCategoria : BaseEntity
    {
        public string Nombre { get; set; }
        public string Caracter { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<ActaEUDetalle> ActaEUDetalle { get; set; } = new HashSet<ActaEUDetalle>();
    }
}
