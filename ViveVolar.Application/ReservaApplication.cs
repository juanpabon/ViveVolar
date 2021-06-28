using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Application
{
    public class ReservaApplication : IReservaApplication
    {
        private IReservaService _reservaService;
        public ReservaApplication(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        public async Task<string> AddReserva(IReserva reserva)
        {
           return await _reservaService.AddReserva(reserva);
        }

        public async Task<IRespuestaReserva> ConsultarReserva(IBuscarReserva buscarReserva)
        {
            return await _reservaService.ConsultarReserva(buscarReserva);
        }

        public async Task<bool> PagarReserva(int IdReserva)
        {
            return await _reservaService.PagarReserva(IdReserva);
        }
    }
}
