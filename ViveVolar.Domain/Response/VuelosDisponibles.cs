using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Response
{
    public class VuelosDisponibles : IVuelosDisponibles
    {
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int CantidadSillas { get; set; }
        public int SillasDisponibles { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public double Precio { get; set; }
        public string TipoVuelo { get; set; }
    }
}
