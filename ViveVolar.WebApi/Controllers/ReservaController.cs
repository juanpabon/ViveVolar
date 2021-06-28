using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Application;
using ViveVolar.Domain.Models;
using ViveVolar.Domain.Request;
using ViveVolar.Domain.Response;
using ViveVolar.WebApi.DTOs;

namespace ViveVolar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        IReservaApplication _reservaApplication;
        IValidarVuelo _validarVuelo;
        public ReservaController(IReservaApplication reservaApplication,IValidarVuelo validarVuelo)
        {
            _reservaApplication = reservaApplication;
            _validarVuelo = validarVuelo;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> AddReserva([FromBody] ReservaDTO dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                if (dto.Cantidad > 0)
                {
                    if (await _validarVuelo.ValidarVuelo(dto.VueloId))
                    {
                        IReserva reserva = new ReservaModel();
                        ICliente cliente = new ClienteModel();

                        cliente.Direccion = dto.CLiente.Direccion;
                        cliente.Email = dto.CLiente.Email;
                        cliente.Identificacion = dto.CLiente.Identificacion;
                        cliente.Nombre = dto.CLiente.Nombre;
                        cliente.Telefono = dto.CLiente.Telefono;
                        cliente.TipoIdentificacion = dto.CLiente.TipoIdentificacion;

                        reserva.Cantidad = dto.Cantidad;
                        reserva.Cliente = cliente;
                        reserva.PrecioReserva = dto.PrecioReserva;
                        reserva.VueloId = dto.VueloId;

                        string codigoReserva = (await _reservaApplication.AddReserva(reserva)).ToUpper();
                        if (!String.IsNullOrEmpty(codigoReserva))
                        {
                            if (await _validarVuelo.RestarDisponibilidad(dto.VueloId, dto.Cantidad))
                            {
                                _Respuesta.Exito = 1;
                                _Respuesta.Data = codigoReserva;
                            }
                        }
                        else
                        {
                            _Respuesta.Mensaje = "Error al registrar la reserva";
                        }
                    }
                    else
                    {
                        _Respuesta.Mensaje = "El vuelo indicado no existe";
                    }
                }
                else
                {
                    _Respuesta.Mensaje = "Debe indicar un cantidad mayor a 0";
                }
            }
            catch (Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> ConsultarReserva([FromBody] BuscarReservaDTO dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                IBuscarReserva buscarReserva = new BuscarResevaModel();
                buscarReserva.CodigoReserva = dto.CodigoReserva.ToUpper();
                buscarReserva.Nombre = dto.Nombre;
                _Respuesta.Data= await _reservaApplication.ConsultarReserva(buscarReserva);
                _Respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }
        [HttpPut]
        [Route("Pay")]
        public async Task<IActionResult> PagarReserva([FromBody] PagarReservaDTO dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                if (await _reservaApplication.PagarReserva(dto.Id))
                    _Respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }
    }
}
