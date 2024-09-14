using Entity.Dtos;
using Microsoft.Extensions.Configuration;
using Repository.Helpers;
using Repository.Interfaces;
using Security.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Repository.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        TokenServices _tokenService = new TokenServices();
        readonly IConfiguration _config;
        DBContext dbContext = new DBContext();
        ResponseLoginDto resultUsuario = new ResponseLoginDto();
        
        DataTable tblResult;
        SqlConnection con;

        public UsersRepository(IConfiguration config)
        {
            _config = config;
        }

        public ResponseLoginDto Login(string userName, string passWord)
        {

            var resultUsuario = new ResponseLoginDto();

            using (var con = new SqlConnection(dbContext.ObtenerCadenaDbConexSQL(_config["config:urlConex"])))
            {
                try
                {
                    con.Open();

                    using (var cmd = new SqlCommand(STORE_PROCEDURES.GET_LOGIN, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@passWord", passWord);
                        cmd.Parameters.AddWithValue("@status", true);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var codigo = reader["codigo"].ToString();

                                if (codigo == "Ok")
                                {
                                    var usuarioDto = new Usuario
                                    {
                                        idUsuario = Convert.ToInt32(reader["idUsuario"]),
                                        usuario = reader["usuario"].ToString(),
                                        nombreUsuario = reader["nombreUsuario"].ToString(),
                                        rol = Convert.ToInt32(reader["rol"]),
                                        estado = reader["estado"].ToString(),
                                        token = _tokenService.generateTokenJwt(_config, userName),
                                        fechaCreacion = reader["fechaCreacion"] == DBNull.Value
                                            ? default(DateTime) : Convert.ToDateTime(reader["fechaCreacion"])
                                        };

                                    resultUsuario.codigo = codigo;
                                    resultUsuario.usuario = usuarioDto;
                                }
                                else
                                {
                                    resultUsuario.codigo = "Error";
                                }
                            }
                            else
                            {
                                resultUsuario.codigo = "Error";
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new InvalidOperationException("Ah ocurrido un error al consultar la base de datos.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error encontrado.", ex);
                }
            }

            return resultUsuario;
        }

    }
}
