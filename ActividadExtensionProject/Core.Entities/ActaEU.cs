using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("ActasEU")]
    public class ActaEU : BaseEntity 
    {
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }


        public ICollection<ActaEUDetalle> ActaEUDetalle { get; set; } = new HashSet<ActaEUDetalle>();

    }
}
