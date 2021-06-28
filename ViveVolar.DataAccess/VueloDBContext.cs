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
    public interface IVueloDbContext
    {
        Task<bool> Crear(Vuelo vuelo);
        Task<List<Vuelo>> BuscarVuelos(IBuscarVuelo buscarVuelo);
        Task<bool> ValidarVuelo(int Id);
        Task<bool> RestarDisponibilidad(int Id, int cantidad);
    }
    public class VueloDBContext : IVueloDbContext
    {
        DbSet<Vuelo> _vuelos;
        ApiDbContext _ctx;
        public VueloDBContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _vuelos =ctx.Set<Vuelo>();
        }
        public async Task<bool> Crear(Vuelo vuelo)
        {
            if(vuelo.Id.Equals(0))
            {
                await _vuelos.AddAsync(vuelo);
            }
            else
            {
                _ctx.Entry(vuelo).State = EntityState.Modified;
            }
            await _ctx.SaveChangesAsync();
            return true;
        }
        public async Task<List<Vuelo>> BuscarVuelos(IBuscarVuelo buscarVuelo)
        {
            List<Vuelo> result = new();
            result = await _vuelos.Where(x => x.FechaSalida.Date >= buscarVuelo.FechaInicio.Date)
                            .Where(x => x.FechaSalida.Date <= buscarVuelo.FechaFin.Date)
                            .Where(x => x.CiudadOrigen == buscarVuelo.Origen)
                            .Where(x => x.CiudadDestino == buscarVuelo.Destino)
                            .Where(x => x.SillasDisponibles >= buscarVuelo.cantidadPasajeros)
                            .OrderBy(x => x.Precio).ToListAsync();           

            return result;
        }
        public async Task<bool> ValidarVuelo(int Id)
        {
            var result=await _vuelos.FindAsync(Id);
            if(result!=null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> RestarDisponibilidad(int Id, int cantidad)
        {
            var vuelo =await _vuelos.FindAsync(Id);
            if (vuelo != null)
            {
                if(vuelo.SillasDisponibles-cantidad>=0)
                {
                    _ctx.Entry(vuelo).State = EntityState.Modified;
                    vuelo.SillasDisponibles -= cantidad;
                    await _ctx.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
