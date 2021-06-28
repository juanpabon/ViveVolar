using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IReserva
    {
        int Id { get; set; }
        DateTime FechaReserva { get; set; }
        int Cantidad { get; set; }
        double PrecioReserva { get; set; }
        string CodigoReserva { get; set; }
        ICliente Cliente { get; set; }
        string Estado { get; set; }
        int VueloId { get; set; }
        int ClienteId { get; set; }
    }
}
