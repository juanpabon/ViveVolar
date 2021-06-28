using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IVuelosDisponibles
    {
        int Id { get; set; }
        DateTime FechaSalida { get; set; }
        DateTime FechaLlegada { get; set; }
        int CantidadSillas { get; set; }
        int SillasDisponibles { get; set; }
        string CiudadOrigen { get; set; }
        string CiudadDestino { get; set; }
        double Precio { get; set; }
        string TipoVuelo { get; set; }
    }
}
