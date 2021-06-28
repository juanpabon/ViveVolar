using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IBuscarReserva
    {
        string Nombre { get; set; }
        string CodigoReserva { get; set; }
    }
}
