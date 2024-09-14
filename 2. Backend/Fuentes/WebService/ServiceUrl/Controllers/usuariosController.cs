using Business.Interfaces;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        IUsersServices _service;

        public usuariosController(IUsersServices Service)
        {
            _service = Service;
        }

        [HttpGet]
        public string Get()
        {
            return "El API Rest funciona coreectamente";
        }

        [HttpPost]
        [Route("doLogin")]
        public ResponseLoginDto Login([FromBody] LoginDto dto)
        {
            return _service.Login(dto.userName, dto.passWord);
        }
    }
}
