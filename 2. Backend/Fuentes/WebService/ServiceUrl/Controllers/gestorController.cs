using Business.Interfaces;
using Entity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gestorController : ControllerBase
    {
        IGestorServices _service;

        public gestorController(IGestorServices Service)
        {
            _service = Service;
        }

        // Metodo GET que obtiene todas las empresas
        // GET: api/gestor/getEntidades
        [Authorize]
        [HttpGet("getEntidades")]
        public IEnumerable<EntidadDto> getEntidades()
        {
            return _service.getEntidades();
        }

        // Metodo SET que graba una nueva entidad
        // POST: api/gestor/setEntidades
        [Authorize]
        [HttpPost("setEntidades")]
        public ResultDto setEntidades([FromBody] EntidadDto dto)
        {
            return _service.setEntidades(dto);
        }

        // Metodo PUT que actualiza una aeronave
        [Authorize]
        // PUT: api/gestor/putEntidades/{id}
        [HttpPut("putEntidades/{id}")]
        public ResultDto putEntidades([FromBody] EntidadDto dto, int id)
        {
            return _service.putEntidades(dto, id);
        }

        // Metodo DELETE que elimina una aeronave
        [Authorize]
        // DELETE: api/gestor/deleteEntidades/{id}
        [HttpDelete("deleteEntidades/{id}")]
        public ResultDto deleteEntidades(int id)
        {
            return _service.deleteEntidades(id);
        }


        // Metodo GET que obtiene todos los empleados
        [Authorize]
        // GET: api/gestor/getEmpleados
        [HttpGet("getEmpleados/{id}")]
        public IEnumerable<EmpleadoDto> getEmpleados(int id)
        {
            return _service.getEmpleados(id);
        }

        // Metodo POST que se encarga de crear un nuevo piloto
        [Authorize]
        // POST: api/gestor/setEmpleados
        [HttpPost("setEmpleados")]
        public ResultDto setEmpleados([FromBody] EmpleadoDto dto)
        {
            return _service.setEmpleados(dto);
        }

        // Metodo PUT que se encarga de Actualizar un empleado
        [Authorize]
        // PUT: api/gestor/putEmpleado/{id}
        [HttpPut("putEmpleado/{id}")]
        public ResultDto putPilotos([FromBody] EmpleadoDto dto, int id)
        {
            return _service.putEmpleado(dto, id);
        }

        // Metodo DELETE que elimina un piloto
        [Authorize]
        // DELETE: api/gestor/deleteEmpleado/{id}
        [HttpDelete("deleteEmpleado/{id}")]
        public ResultDto deleteEmpleado(int id)
        {
            return _service.deleteEmpleado(id);
        }

        // Metodo GET que trae las propiedades de una tabla para formularios
        // GET: api/gestor/getPropiedades
        [HttpGet("getPropiedades")]
        public IEnumerable<PropiedadesTablaDto> getPropiedades(string nombreTabla)
        {
            return _service.getPropiedades(nombreTabla);
        }

        // GET: api/<libraryController>
        [HttpGet]
        public string Get()
        {
            return "El controlador sirve";
        }
    }
}
