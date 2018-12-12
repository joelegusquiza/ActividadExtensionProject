using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("Carreras")]
    public class Carrera : BaseEntity
    { 
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public ICollection<Estudiante> Estudiantes { get; set; } = new HashSet<Estudiante>();
        public ICollection<ActaEU> Actas { get; set; } = new HashSet<ActaEU>();

    }
}
