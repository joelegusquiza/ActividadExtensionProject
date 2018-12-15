using System;
using System.Collections.Generic;
using System.Text;
using static Core.Constants;

namespace Core.DTOs.Estudiantes
{
    public class IndexEstudianteViewModel
    {
        public List<EstudianteViewModel> Estudiantes { get; set; } = new List<EstudianteViewModel>();
    }

    public class EstudianteViewModel
    {
        public int Id { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }       
        public string Carrera { get; set; }

    }
}