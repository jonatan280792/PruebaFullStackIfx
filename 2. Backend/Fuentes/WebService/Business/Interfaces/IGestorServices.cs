using Entity.Dtos;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IGestorServices
    {
        List<EntidadDto> getEntidades();
        ResultDto setEntidades(EntidadDto dto);
        ResultDto putEntidades(EntidadDto dto, int id);
        ResultDto deleteEntidades(int id);

        List<EmpleadoDto> getEmpleados(int id);
        ResultDto setEmpleados(EmpleadoDto dto);
        ResultDto putEmpleado(EmpleadoDto dto, int id);
        ResultDto deleteEmpleado(int id);

        List<PropiedadesTablaDto> getPropiedades(string nombreTabla);
    }
}
