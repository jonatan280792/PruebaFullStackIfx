using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entity.Mappers
{
    public static class GestorMapper
    {
        public static List<EntidadDto> AsLstEntidades(this DataTable table)
        {
            var lst = new List<EntidadDto>();

            if (table == null) return lst;

            foreach (DataRow row in table.Rows)
            {
                var entidadDto = new EntidadDto
                {
                    idEntidad = row.Field<int>("idEntidad"),
                    entidad = row.Field<string>("entidad"),
                    sector = row.Field<string>("sector"),
                    direccion = row.Field<string>("direccion"),
                    estado = row.Field<bool>("estado"),
                    descripcion = row.Field<string>("descripcion"),
                    fechaCreacion = row.Field<DateTime>("fechaCreacion")
                };

                lst.Add(entidadDto);
            }

            return lst;
        }

        // MAPEA LOS CAMPOS DE LA TABLA EPLEADOS
        public static List<EmpleadoDto> AsLstEmpleados(this DataTable table)
        {
            var lst = new List<EmpleadoDto>();

            if (table == null) return lst;

            foreach (DataRow row in table.Rows)
            {
                var entidadDto = new EmpleadoDto
                {
                    idEmpleado = row.Field<int>("idEmpleado"),
                    nombres = row.Field<string>("nombres"),
                    apellidos = row.Field<string>("apellidos"),
                    idEntidad = row.Field<int>("idEntidad"),
                    estado = row.Field<bool>("estado"),
                    fechaIngreso = row.Field<DateTime>("fechaIngreso"),
                    fechaCreacion = row.Field<DateTime>("fechaCreacion")

                };

                lst.Add(entidadDto);
            }

            return lst;
        }

        // MAPEA LOS CAMPOS DE LA PROPIEDAD DE LA TABLA
        public static List<PropiedadesTablaDto> AsPropiedadTabla(this DataTable table)
        {
            var lst = new List<PropiedadesTablaDto>();

            if (table == null) return lst;

            foreach (DataRow row in table.Rows)
            {
                var entidadDto = new PropiedadesTablaDto
                {
                    idCampo = row.Field<int>("idCampo"),
                    nombreCampo = row.Field<string>("nombreCampo"),
                    tipoCampo = row.Field<string>("tipoCampo"),
                    longitud = row.Field<short>("longitud"),
                    obligatorio = row.Field<int>("obligatorio") == 1

                };

                lst.Add(entidadDto);
            }

            return lst;
        }
    }
}
