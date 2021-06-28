using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Domain.Models;
using ViveVolar.Domain.Response;
using ViveVolar.WebApi.DTOs;

namespace ViveVolar.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUserApplication _userApplication;
        public UsuarioController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                IUser user = new UserModels();
                user.Login = dto.Login;
                user.Password = dto.Password;
                var res = await _userApplication.Crear(user);
                switch (res.Success)
                {
                    case 0:
                        _Respuesta.Mensaje = "Se produjo algun error al registrar el usuario";
                        break;
                    case 1:
                        _Respuesta.Exito = 1;
                        break;
                    case 2:
                        _Respuesta.Mensaje = "Usuario ya existe";
                        break;
                    case 3:
                        _Respuesta.Mensaje = "Contraseña debe contener una mayuscula, una minuscula, un caracter especial y minimo 5 y maximo 9 caracteres";
                        break;
                }
            }
            catch (Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                IUser user = new UserModels();
                user.Login = dto.Login;
                user.Password = dto.Password;
                var result = await _userApplication.Login(user);
                switch (result.Success)
                {
                    case 0:
                        _Respuesta.Mensaje = "Se produjo algun error para validar el usuario";
                        break;
                    case 1:
                        _Respuesta.Exito = 1;
                        _Respuesta.Data = result;
                        break;
                    case 2:
                        _Respuesta.Mensaje = "Usuario o contraseña incorecto!";
                        break;
                }
            }
            catch (Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }
    }
}
