using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Reportes
{
    public class ReporteMensualIndexViewModel
    {
        public List<ReporteMensualViewModel> Items { get; set; } = new List<ReporteMensualViewModel>();
    }

    public class ReporteMensualViewModel
    {
        public string ActividadEU { get; set; }
        public string Tarea { get; set; }
        public int Cantidad { get; set; }
        public string Lugar { get; set; }
        public string Organizador { get; set; }
        public int EjecutorVaron { get; set; }
        public int EjecutorMujer { get; set; }
        public int BeneficiariosInstitucion { get; set; }
        public int BeneficiarosPersonasVaron { get; set;}
        public int BeneficiariosPersonasMujer { get; set; }
    }
}

