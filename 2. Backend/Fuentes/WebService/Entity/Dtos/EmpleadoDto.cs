using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class EmpleadoDto
    {
        public int? idEmpleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int idEntidad { get; set; }
        public bool? estado { get; set; }
        public DateTime? fechaIngreso { get; set; }
        public DateTime? fechaCreacion { get; set; }
    }
}
