using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Carreras
{
    public class UpsertCarreraViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}
