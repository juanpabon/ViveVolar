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
    public interface IVueloRepository 
    {
        Task<bool> Crear(Vuelo vuelo);
        Task<List<Vuelo>> BuscarVuelos(IBuscarVuelo buscarVuelo);
        Task<bool> ValidarVuelo(int Id);
        Task<bool> RestarDisponibilidad(int Id, int cantidad);
    }
    public class VueloRepository :IVueloRepository
    {
        IVueloDbContext _ctx;
        public VueloRepository(IVueloDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> Crear(Vuelo vuelo)
        {
            return await _ctx.Crear(vuelo);
        }
        public async Task<List<Vuelo>> BuscarVuelos(IBuscarVuelo buscarVuelo)
        {
            return await _ctx.BuscarVuelos(buscarVuelo);
        }
        public async Task<bool> ValidarVuelo(int Id)
        {
            return await _ctx.ValidarVuelo(Id);
        }
        public async Task<bool> RestarDisponibilidad(int Id, int cantidad)
        {
            return await _ctx.RestarDisponibilidad(Id, cantidad);
        }
    }
}
