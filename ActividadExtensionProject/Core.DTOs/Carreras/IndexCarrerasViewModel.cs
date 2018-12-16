using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Carreras
{
    public class IndexCarrerasViewModel
    {
        public List<CarreraViewModel> Carreras { get; set; } = new List<CarreraViewModel>();
    }

    public class CarreraViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}
