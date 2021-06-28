using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Application
{
    public class UserApplication : IUserApplication
    {
        private IUserService _userService;
        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IRespuestaUser> Crear(IUser user)
        {
            return await _userService.Crear(user);
        }

        public async Task<IRespuestaUser> Login(IUser user)
        {
            return await _userService.Login(user);
        }
    }
}
