using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IReservaApplication
    {
        Task<string> AddReserva(IReserva reserva);
        Task<bool> PagarReserva(int IdReserva);
        Task<IRespuestaReserva> ConsultarReserva(IBuscarReserva buscarReserva);
    }
}
