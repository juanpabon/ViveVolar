using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Models
{
    public class VueloInternacionalModel : IVuelo
    {
        private readonly List<IReserva> reservas = new();
        public VueloInternacionalModel()
        {
            TipoVuelo = "Internacional";
        }
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int CantidadSillas { get; set; }
        public int SillasDisponibles { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        private double PrecioBase { get; set; }
        public double Precio { get => CalcularPrecio(); set => PrecioBase = value; }
        public string TipoVuelo { get; set; }
        public IReadOnlyList<IReserva> Reservas => reservas.AsReadOnly();

        public void AddReserva(IReserva reserva)
        {
            reservas.Add(reserva);
            SillasDisponibles -= reserva.Cantidad;
        }

        public double CalcularPrecio()
        {
            return (PrecioBase *0.19)+PrecioBase ;
        }
    }
}
