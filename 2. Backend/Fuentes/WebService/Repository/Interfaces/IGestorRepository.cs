using Entity.Dtos;
using System.Data;

namespace Repository.Interfaces
{
    public interface IGestorRepository
    {
        // CRUD Entidades
        DataTable getEntidades();




        DataTable setEntidades(EntidadDto dto);
        DataTable putEntidades(EntidadDto dto, int id);
        DataTable deleteEntidades(int id);


        // CRUD Empleados
        DataTable getEmpleados(int id);
        DataTable setEmpleados(EmpleadoDto dto);
        DataTable putEmpleado(EmpleadoDto dto, int id);
        DataTable deleteEmpleado(int id);


        DataTable getPropiedades(string nombreTabla);
    }
}
