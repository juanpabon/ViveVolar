using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IRespuestaUser
    {
        string Login { get; set; }
        string Token { get; set; }
        int Success { get; set; }
    }
}
