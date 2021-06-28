using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IRespuestaReserva
    {
        DateTime FechaReserva { get; set; }
        int Cantidad { get; set; }
        string Estado { get; set; }
        double PrecioReserva { get; set; }
        string CodigoReserva { get; set; }
        DateTime FechaPago { get; set; }
        DateTime FechaSalida { get; set; }
        DateTime FechaLlegada { get; set; }        
        string CiudadOrigen { get; set; }
        string CiudadDestino { get; set; }
        string TipoVuelo { get; set; }
        string Nombre { get; set; }
        string TipoIdentificacion { get; set; }
        string Identificacion { get; set; }
        string Email { get; set; }
        string Telefono { get; set; }
        string Direccion { get; set; }
    }
}
