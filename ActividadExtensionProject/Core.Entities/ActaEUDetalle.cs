using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("ActasEUDetalles")]
    public class ActaEUDetalle : BaseEntity
    {
        public DateTimeOffset FechaInicio { get; set; }
        public DateTimeOffset FechaFin { get; set; }
        public int HorasRelojRealizadas { get; set; }
        public int HorasExtensionRealizadas { get; set; }
        public string LugarProfesorTutor { get; set; }

        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int? SubCategoriaId { get; set; }
        public SubCategoria SubCategoria { get; set; }
        public int ActaEUId { get; set; }
        public ActaEU Acta { get; set; }
       

    }
}
