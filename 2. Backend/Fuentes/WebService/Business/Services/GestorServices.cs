using Business.Interfaces;
using Entity.Dtos;
using Entity.Mappers;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
    public class GestorServices : IGestorServices
    {
        IGestorRepository _repository;
        public GestorServices(IGestorRepository repository)
        {
            _repository = repository;
        }


        // CRUD Entidades
        public List<EntidadDto> getEntidades() => _repository.getEntidades().AsLstEntidades();


        public ResultDto setEntidades(EntidadDto dto) => _repository.setEntidades(dto).AsResult();
        public ResultDto putEntidades(EntidadDto dto, int id) => _repository.putEntidades(dto, id).AsResult();
        public ResultDto deleteEntidades(int id) => _repository.deleteEntidades(id).AsResult();

        // CRUD Empleados
        public List<EmpleadoDto> getEmpleados(int id) => _repository.getEmpleados(id).AsLstEmpleados();
        public ResultDto setEmpleados(EmpleadoDto dto) => _repository.setEmpleados(dto).AsResult();
        public ResultDto putEmpleado(EmpleadoDto dto, int id) => _repository.putEmpleado(dto, id).AsResult();
        public ResultDto deleteEmpleado(int id) => _repository.deleteEmpleado(id).AsResult();

        public List<PropiedadesTablaDto> getPropiedades(string nombreTabla) => _repository.getPropiedades(nombreTabla).AsPropiedadTabla();
    }
}
