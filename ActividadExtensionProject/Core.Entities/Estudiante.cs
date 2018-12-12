using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Core.Constants;

namespace Core.Entities
{
    [Table("Estudiantes")]
    public class Estudiante : BaseEntity
    {
        public string CedulaIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Sexo Sexo { get; set; }

        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
        public ICollection<ActaEU> Actas { get; set; } = new HashSet<ActaEU>();
        

    }
}
