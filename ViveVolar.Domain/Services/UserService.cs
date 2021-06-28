using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Domain.Models;
using ViveVolar.Domain.Response;
using ViveVolar.Entities;
using ViveVolar.Repository;
using ViveVolar.Services;

namespace ViveVolar.Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ITokenHandlerService _tokenService;
        private IValidaciones _validacionesService;
        public UserService(IUserRepository userRepository, ITokenHandlerService tokenService, IValidaciones validacionesService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _validacionesService = validacionesService;
        }

        public async Task<IRespuestaUser> Crear(IUser user)
        {
            IRespuestaUser result = new RespuestaUser();
            if (_validacionesService.ValidarPassword(user.Password))
            {
                var exis = await _userRepository.ExisteUsuario(user.Login);
                
                if (exis == null)
                {
                    User _user = new();
                    var hash = HashHelper.Hash(user.Password);
                    _user.Login = user.Login;
                    _user.Password = hash.Password;
                    _user.Sal = hash.Sal;
                    if (await _userRepository.Crear(_user))
                    {
                        result.Success = 1;
                    }
                    else
                    {
                        result.Success = 0;
                    }
                }
                else
                {
                    result.Success = 2;
                }
            }
            else 
            {
                result.Success = 3;
            }
            return result;
        }

        public async Task<IRespuestaUser> Login(IUser user)
        {
            var exis = await _userRepository.ExisteUsuario(user.Login);
            IRespuestaUser result = new RespuestaUser();
            if (exis != null)
            {
                User _user = new();
                if(HashHelper.CheckHash(user.Password,exis.Password,exis.Sal))
                {
                    var pars = new TokenParametersModels()
                    {
                        Id = exis.Id,
                        PasswordHash = exis.Password,
                        Login = exis.Login
                    };
                    var jwtToken = _tokenService.GenerateJwtToken(pars);
                    result.Success = 1;
                    result.Token = jwtToken;
                }
                else
                {
                    result.Success = 2;
                }
            }
            else
            {
                result.Success = 0;
            }
            return result;
        }
    }
}
