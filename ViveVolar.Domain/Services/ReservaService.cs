using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Domain.Response;
using ViveVolar.Entities;
using ViveVolar.Repository;

namespace ViveVolar.Domain.Services
{
    public class ReservaService : IReservaService
    {
        private IReservaRepository _reservaRepository;
        private IValidaciones _validacionesService;
        private ISendEmail _sendEmail;
        public ReservaService(IReservaRepository reservaRepository, IValidaciones validacionesService, ISendEmail sendEmail)
        {
            _reservaRepository = reservaRepository;
            _validacionesService = validacionesService;
            _sendEmail = sendEmail;
        }
        public async Task<string> AddReserva(IReserva reserva)
        {
            Reserva _reserva = new();
            Cliente _cliente = new();

            _cliente.Direccion = reserva.Cliente.Direccion;
            _cliente.Email = reserva.Cliente.Email;
            _cliente.Identificacion = reserva.Cliente.Identificacion;
            _cliente.Nombre = reserva.Cliente.Nombre;
            _cliente.Telefono = reserva.Cliente.Telefono;
            _cliente.TipoIdentificacion = reserva.Cliente.TipoIdentificacion;

            _reserva.Cantidad = reserva.Cantidad;
            _reserva.Cliente = _cliente;
            _reserva.CodigoReserva = _validacionesService.GenerateCode(8);
            _reserva.Estado = reserva.Estado;
            _reserva.FechaReserva = reserva.FechaReserva;
            _reserva.Id = reserva.Id;
            _reserva.PrecioReserva = reserva.PrecioReserva;
            _reserva.VueloId = reserva.VueloId;
             if(await _reservaRepository.AddReserva(_reserva))
            {
                string Subject = $"Reserva {_reserva.CodigoReserva}";
                string Mensaje = $"<p>Hola {_reserva.Cliente.Nombre}</p>" +
                    $"<p>Hemos confirmado la reserva {_reserva.CodigoReserva}</p>" +
                    $"<p>Ciudad Origen:{_reserva.Vuelo.CiudadOrigen}            Ciudad Destino: {_reserva.Vuelo.CiudadDestino}</p>" +
                    $"<p>Fecha Salida: {_reserva.Vuelo.FechaSalida.ToShortDateString()}         Hora: {_reserva.Vuelo.FechaSalida.ToShortTimeString()}</p>" +
                    $"<p>Fecha Llegada: {_reserva.Vuelo.FechaLlegada.ToShortDateString()}       Hora: {_reserva.Vuelo.FechaLlegada.ToShortTimeString()}</p>" +
                    $"<p>Cantidad Asientos: {_reserva.Cantidad}</p>" +
                    $"<p>Estado: {_reserva.Estado}</p>" +
                    $"<p>Precio: {_reserva.PrecioReserva}</p>" +
                    $"<p>Recuerda realizar el pago de tu reserva</p>" +
                    $"<p>Gracias por confiar en nosotros</p>";
                _sendEmail.Send(_cliente.Email, Subject, Mensaje, true);
                return _reserva.CodigoReserva;
            }
            return string.Empty;
        }
        public async Task<bool> PagarReserva(int IdReserva)
        {
            Reserva _reserva = await _reservaRepository.GetReserva(IdReserva);
            if (_reserva != null)
            {
                _reserva.FechaPago = DateTime.Now;
                _reserva.Estado = "Pagado";
                string Subject = $"Pago reserva {_reserva.CodigoReserva}";
                string Mensaje = $"<p>Hola {_reserva.Cliente.Nombre}</p>" +
                    $"<p>Hemos confirmado el pago de la reserva {_reserva.CodigoReserva}</p>" +
                    $"<p>Recuerda la información del viaje:</p>" +
                    $"<p>Ciudad Origen:{_reserva.Vuelo.CiudadOrigen}            Ciudad Destino: {_reserva.Vuelo.CiudadDestino}</p>" +
                    $"<p>Fecha Salida: {_reserva.Vuelo.FechaSalida.ToShortDateString()}         Hora: {_reserva.Vuelo.FechaSalida.ToShortTimeString()}</p>" +
                    $"<p>Fecha Llegada: {_reserva.Vuelo.FechaLlegada.ToShortDateString()}       Hora: {_reserva.Vuelo.FechaLlegada.ToShortTimeString()}</p>" +
                    $"<p>Cantidad Asientos: {_reserva.Cantidad}</p>" +
                    $"<p>Estado: {_reserva.Estado}</p>" +
                    $"<p>Precio: {_reserva.PrecioReserva}</p>" +
                    $"<p>Alista todo para el viaje</p>" +
                    $"<p>Gracias por confiar en nosotros</p>";
                _sendEmail.Send(_reserva.Cliente.Email, Subject, Mensaje, true);
                return await _reservaRepository.AddReserva(_reserva);
            }
            return false;
        }
        public async Task<IRespuestaReserva> ConsultarReserva(IBuscarReserva buscarReserva)
        {
            Reserva _reserva= await _reservaRepository.ConsultarReserva(buscarReserva);
            IRespuestaReserva result = new RespuestaReserva();
            result.Cantidad = _reserva.Cantidad;
            result.CiudadDestino = _reserva.Vuelo.CiudadDestino;
            result.CiudadOrigen = _reserva.Vuelo.CiudadOrigen;
            result.CodigoReserva = _reserva.CodigoReserva;
            result.Direccion = _reserva.Cliente.Direccion;
            result.Email = _reserva.Cliente.Email;
            result.Estado = _reserva.Estado;
            result.FechaLlegada = _reserva.Vuelo.FechaLlegada;
            result.FechaPago = _reserva.FechaPago;
            result.FechaReserva = _reserva.FechaReserva;
            result.FechaSalida = _reserva.Vuelo.FechaSalida;
            result.Identificacion = _reserva.Cliente.Identificacion;
            result.Nombre = _reserva.Cliente.Nombre;
            result.PrecioReserva = _reserva.PrecioReserva;
            result.Telefono = _reserva.Cliente.Telefono;
            result.TipoIdentificacion = _reserva.Cliente.TipoIdentificacion;
            result.TipoVuelo = _reserva.Vuelo.TipoVuelo;
            return result;
        }
    }
}
