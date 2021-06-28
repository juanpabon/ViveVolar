using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Models
{
    public class VueloNacionalModel : IVuelo
    {
        private readonly List<IReserva> reservas = new();
        public VueloNacionalModel()
        {
            TipoVuelo = "Nacional";
        }
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int CantidadSillas { get; set; }
        public int SillasDisponibles { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        private double PrecioBase { get; set; }
        public double Precio { get => CalcularPrecio(); set=>PrecioBase= value; }
        public string TipoVuelo { get; set; }
        public IReadOnlyList<IReserva> Reservas => reservas.AsReadOnly();

        public void AddReserva(IReserva reserva)
        {
            SillasDisponibles -= reserva.Cantidad;
        }

        public double CalcularPrecio()
        {
            return PrecioBase;
        }
    }
}
