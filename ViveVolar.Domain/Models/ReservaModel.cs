using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Models
{
    public class ReservaModel : IReserva
    {
        public ReservaModel()
        {
            Estado = "Reservado";
            FechaReserva = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public int Cantidad { get; set; }
        private double PrecioBaseReserva { get; set; }
        public double PrecioReserva { get => CalcularPrecioReserva(); set => PrecioBaseReserva=value; }
        public string Estado { get; set; }
        public string CodigoReserva { get; set; }
        public ICliente Cliente { get; set; }
        public int VueloId { get; set; }
        public int ClienteId { get; set; }

        private double CalcularPrecioReserva()
        {
            return PrecioBaseReserva;
        }

        
    }
}
