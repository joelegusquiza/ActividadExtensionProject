using Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Reportes
{
    public class ReporteIndexViewModel
    {
        public int CarreraId { get; set; }
        public int Mes { get; set; }
        public int Anho { get; set; }
        public List<DropDownViewModel<int>> CarrerasExistentes { get; set; } = new List<DropDownViewModel<int>>();
        public List<DropDownViewModel<int>> MesesExistentes { get; set; } = new List<DropDownViewModel<int>>();
        public List<DropDownViewModel<int>> AnhosExistentes { get; set; } = new List<DropDownViewModel<int>>();
        public List<ReporteItemViewModel> Actividades { get; set; } = new List<ReporteItemViewModel>();
    }

    //public class ReporteViewModel
    //{
    //    public string ActividadEU { get; set; }
    //    public List<ReporteItemViewModel> Tareas { get; set; } = new List<ReporteItemViewModel>();
    //}
    public class ReporteItemViewModel
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

