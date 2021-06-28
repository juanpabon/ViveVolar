using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IUserApplication
    {
        Task<IRespuestaUser> Crear(IUser user);
        Task<IRespuestaUser> Login(IUser user);
    }
}
