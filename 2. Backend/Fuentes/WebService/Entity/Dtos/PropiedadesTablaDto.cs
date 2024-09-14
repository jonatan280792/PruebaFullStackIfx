using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class PropiedadesTablaDto
    {
        public int idCampo { get; set; }
        public string nombreCampo { get; set; }
        public string tipoCampo { get; set; }
        public short longitud { get; set; }
        public bool obligatorio { get; set; }
    }
}
