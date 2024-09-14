using Entity.Dtos;
using Microsoft.Extensions.Configuration;
using Repository.Helpers;
using Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Repositories
{
    public class GestorRepository : IGestorRepository
    {
        readonly IConfiguration _config;
        DBContext dbContext = new DBContext();
        DataTable tblResult;
        SqlConnection con;

        public GestorRepository(IConfiguration config)
        {
            _config = config;
        }

        public DataTable getEntidades()
        {
            DataTable tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.GET_ENTIDADES, con))
                {
                    con.Open();
                    
                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.AddWithValue("@estado", true);                    
                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving entidades.", ex);
            }

            return tblResult;
        }


        public DataTable setEntidades(EntidadDto dto)
        {
            DataTable tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.SET_ENTIDADES, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    
                    cmd.SelectCommand.Parameters.AddWithValue("@entidad", dto.entidad ?? (object)DBNull.Value);
                    cmd.SelectCommand.Parameters.AddWithValue("@sector", dto.sector ?? (object)DBNull.Value);
                    cmd.SelectCommand.Parameters.AddWithValue("@direccion", dto.direccion ?? (object)DBNull.Value);
                    cmd.SelectCommand.Parameters.AddWithValue("@estado", dto.estado);
                    cmd.SelectCommand.Parameters.AddWithValue("@descripcion", dto.descripcion ?? (object)DBNull.Value);
                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while setting entidades.", ex);
            }

            return tblResult;
        }

        public DataTable putEntidades(EntidadDto dto, int id)
        {
            DataTable tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.PUT_ENTIDADES, con))
                {
                    con.Open();
                    
                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;                    
                    cmd.SelectCommand.Parameters.AddWithValue("@id", id);                    
                    cmd.SelectCommand.Parameters.AddWithValue("@entidad", string.IsNullOrEmpty(dto.entidad) ? (object)DBNull.Value : dto.entidad);
                    cmd.SelectCommand.Parameters.AddWithValue("@sector", string.IsNullOrEmpty(dto.sector) ? (object)DBNull.Value : dto.sector);
                    cmd.SelectCommand.Parameters.AddWithValue("@direccion", string.IsNullOrEmpty(dto.direccion) ? (object)DBNull.Value : dto.direccion);
                    cmd.SelectCommand.Parameters.AddWithValue("@estado", dto.estado);
                    cmd.SelectCommand.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(dto.descripcion) ? (object)DBNull.Value : dto.descripcion);

                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating aeronaves.", ex);
            }

            return tblResult;
        }

        public DataTable deleteEntidades(int id)
        {

            var tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.DELETE_ENTIDADES, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting entities.", ex);
            }

            return tblResult;
        }

        public DataTable getEmpleados(int id)
        {

            DataTable tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.GET_EMPLEADOS, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.Add("@idEntidad", SqlDbType.Int).Value = id;
                    cmd.SelectCommand.Parameters.AddWithValue("@estado", true);
                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving entidades.", ex);
            }

            return tblResult;
        }

        public DataTable setEmpleados(EmpleadoDto dto)
        {
            DataTable tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.SET_EMPLEADOS, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.AddWithValue("@nombres", dto.nombres ?? (object)DBNull.Value);
                    cmd.SelectCommand.Parameters.AddWithValue("@apellidos", dto.apellidos ?? (object)DBNull.Value);
                    cmd.SelectCommand.Parameters.AddWithValue("@idEntidad", dto.idEntidad);
                    cmd.SelectCommand.Parameters.AddWithValue("@estado", dto.estado);
                    //cmd.SelectCommand.Parameters.AddWithValue("@fechaIngreso", dto.fechaIngreso);
                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while setting entidades.", ex);
            }

            return tblResult;
        }

        public DataTable putEmpleado(EmpleadoDto dto, int id)
        {

            DataTable tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.PUT_EMPLEADOS, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.AddWithValue("@id", id);
                    cmd.SelectCommand.Parameters.AddWithValue("@nombres", string.IsNullOrEmpty(dto.nombres) ? (object)DBNull.Value : dto.nombres);
                    cmd.SelectCommand.Parameters.AddWithValue("@apellidos", string.IsNullOrEmpty(dto.apellidos) ? (object)DBNull.Value : dto.apellidos);
                    cmd.SelectCommand.Parameters.AddWithValue("@idEntidad", dto.idEntidad);
                    cmd.SelectCommand.Parameters.AddWithValue("@estado", dto.estado);
                    //cmd.SelectCommand.Parameters.AddWithValue("@fechaIngreso", dto.fechaIngreso);

                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating aeronaves.", ex);
            }

            return tblResult;
        }

        public DataTable deleteEmpleado(int id)
        {

            var tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.DELETE_EMPLEADOS, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting entities.", ex);
            }

            return tblResult;
        
        }

        public DataTable getPropiedades(string nombreTabla)
        {
            var tblResult = new DataTable();

            try
            {
                using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
                using (var cmd = new SqlDataAdapter(STORE_PROCEDURES.GET_PROPIEDADES, con))
                {
                    con.Open();

                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.Add("@nombreTabla", SqlDbType.VarChar).Value = nombreTabla;

                    cmd.Fill(tblResult);
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"SQL Error: {ex.Message} (Code: {ex.ErrorCode})", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while get properties.", ex);
            }

            return tblResult;
        }
    }
}
