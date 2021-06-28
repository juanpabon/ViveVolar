using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.DataAccess;
using ViveVolar.Entities;

namespace ViveVolar.Repository
{
    public interface IReservaRepository
    {
        Task<bool> AddReserva(Reserva reserva);
        Task<Reserva> ConsultarReserva(IBuscarReserva buscarReserva);
        Task<Reserva> GetReserva(int IdReserva);
    }
    public class ReservaRepository : IReservaRepository
    {
        IReservaDBContext _ctx;
        public ReservaRepository(IReservaDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> AddReserva(Reserva reserva)
        {
            return await _ctx.AddReserva(reserva);
        }

        public async Task<Reserva> ConsultarReserva(IBuscarReserva buscarReserva)
        {
            return await _ctx.ConsultarReserva(buscarReserva);
        }

        public async Task<Reserva> GetReserva(int IdReserva)
        {
            return await _ctx.GetReserva(IdReserva);
        }
    }
}
