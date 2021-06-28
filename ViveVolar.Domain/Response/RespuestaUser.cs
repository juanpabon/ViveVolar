using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Response
{
    public class RespuestaUser : IRespuestaUser
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public int Success { get; set; }
    }
}
