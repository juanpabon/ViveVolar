using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Models
{
    public class ReservaPagadaModels : IReserva
    {
        public ReservaPagadaModels()
        {
            Estado = "Pagada";
            FechaPago = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public int Cantidad { get; set; }
        public double PrecioReserva { get; set; }
        public string Estado { get; set; }
        public string CodigoReserva { get; set; }
        public ICliente Cliente { get; set; }
        public DateTime FechaPago { get; set; }
        public int VueloId { get; set; }
        public int ClienteId { get; set; }
    }
}
