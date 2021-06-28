using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Entities;

namespace ViveVolar.DataAccess
{
    public interface IReservaDBContext
    {
        Task<bool> AddReserva(Reserva reserva);
        Task<Reserva> ConsultarReserva(IBuscarReserva buscarReserva);
        Task<Reserva> GetReserva(int IdReserva);
    }
    public class ReservaDBContext : IReservaDBContext
    {
        DbSet<Reserva> _reservas;
        ApiDbContext _ctx;
        public ReservaDBContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _reservas = ctx.Set<Reserva>();
        }
        public async Task<bool> AddReserva(Reserva reserva)
        {
            if(reserva.Id.Equals(0))
            {
                await _reservas.AddAsync(reserva);
            }
            else
            {
                _ctx.Entry(reserva).State = EntityState.Modified;
            }
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<Reserva> ConsultarReserva(IBuscarReserva buscarReserva)
        {
            Reserva result = new();
            result= await _reservas.Where(x => x.Cliente.Nombre == buscarReserva.Nombre)
                            .Where(x => x.CodigoReserva == buscarReserva.CodigoReserva)
                            .Include(x=>x.Cliente)
                            .Include(x=>x.Vuelo)
                            .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Reserva> GetReserva(int IdReserva)
        {
            return await _reservas.Where(x=>x.Id==IdReserva)
                            .Include(x => x.Cliente)
                            .Include(x => x.Vuelo)
                            .FirstOrDefaultAsync();
        }
    }
}
