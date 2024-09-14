using System;

namespace Entity.Dtos
{
    public class ResponseLoginDto
    {
        public string codigo { get; set; }
        public Usuario usuario { get; set; }
    }

    public class Usuario {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string nombreUsuario { get; set; }
        public int rol { get; set; }
        public string estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string token { get; set; }
    }
}
