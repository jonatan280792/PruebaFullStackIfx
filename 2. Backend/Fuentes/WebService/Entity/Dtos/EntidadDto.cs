using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class EntidadDto
    {
        public int? idEntidad { get; set; }
        public string entidad { get; set; }
        public string sector { get; set; }
        public string direccion { get; set; }
        public bool? estado { get; set; }
        public string descripcion { get; set; }
        public DateTime? fechaCreacion { get; set; }
    }
}
