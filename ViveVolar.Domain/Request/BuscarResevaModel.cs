using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Request
{
    public class BuscarResevaModel : IBuscarReserva
    {
        public string Nombre { get; set; }
        public string CodigoReserva { get; set; }
    }
}
