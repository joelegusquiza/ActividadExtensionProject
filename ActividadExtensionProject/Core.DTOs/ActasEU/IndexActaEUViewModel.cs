using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.ActasEU
{
    public class IndexActaEUViewModel
    {
        public List<ActaEUViewModel> Actas { get; set; } = new List<ActaEUViewModel>();
    }

    public class ActaEUViewModel
    {
        public int EstudianteId { get; set; }
        public string Estudiante { get; set; }
        public int CarreraId { get; set; }
        public string Carrera { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
