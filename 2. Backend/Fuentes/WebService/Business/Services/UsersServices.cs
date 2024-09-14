using Business.Interfaces;
using Entity.Dtos;
using Entity.Mappers;
using Repository.Interfaces;
namespace Business.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _repository;
        public UsersServices(IUsersRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Encargado de validar usuario y contraseñ, y si es correcto generar un tokenJwt.
        /// </summary>
        /// <param name="userName">Usuario que se quiere loguear.</param>
        /// <param name="passWord">Contraseña del usuario.</param>
        /// <returns>A <see cref="ResponseLoginDto"/> Representa el DTO de respuesta del usuario.</returns>
        public ResponseLoginDto Login(string userName, string passWord)
        {
            return _repository.Login(userName, passWord);
        }
    }
}
