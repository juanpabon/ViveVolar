using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Application;
using ViveVolar.Domain.Models;
using ViveVolar.Domain.Request;
using ViveVolar.Domain.Response;
using ViveVolar.WebApi.DTOs;

namespace ViveVolar.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        IVueloApplication _vueloApplication;
        public VueloController(IVueloApplication vueloApllication)
        {
            _vueloApplication = vueloApllication;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Save([FromBody] VueloDTO dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                IVuelo vueloModel = dto.TipoVuelo switch
                {
                    "Nacional" => new VueloNacionalModel(),
                    "Internacional" => new VueloInternacionalModel(),
                    _ => null,
                };
                if (vueloModel != null)
                {
                    if (dto.FechaSalida >= DateTime.Now)
                    {
                        if (dto.FechaLlegada > dto.FechaSalida)
                        {
                            vueloModel.CantidadSillas = dto.CantidadSillas;
                            vueloModel.CiudadDestino = dto.CiudadDestino;
                            vueloModel.CiudadOrigen = dto.CiudadOrigen;
                            vueloModel.FechaLlegada = dto.FechaLlegada;
                            vueloModel.FechaSalida = dto.FechaSalida;
                            vueloModel.Id = dto.Id;
                            vueloModel.Precio = dto.Precio;
                            vueloModel.SillasDisponibles = dto.CantidadSillas;
                            if (await _vueloApplication.Crear(vueloModel))
                            {
                                _Respuesta.Exito = 1;
                            }
                            else
                            {
                                _Respuesta.Mensaje = "No se logro registrar el vuelo";
                            }
                        }
                        else 
                        {
                            _Respuesta.Mensaje = "La fecha de llegada debe ser mayor a la de salida";
                        }
                    }
                    else
                    {
                        _Respuesta.Mensaje = "La fecha de salida debe ser mayor a la actual";
                    }
                }
                else
                {
                    _Respuesta.Mensaje = "Tipo de vuelo no valido";
                }
            }
            catch(Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> BuscarVuelo([FromBody] BuscarVueloDto dto)
        {
            Respuesta _Respuesta = new()
            {
                Exito = 0
            };
            try
            {
                if (dto.FechaInicio >= DateTime.Now)
                {
                    if (dto.FechaFin > dto.FechaInicio)
                    {
                        IBuscarVuelo buscarVuelo = new BuscarVueloModel();
                        buscarVuelo.cantidadPasajeros = dto.cantidadPasajeros;
                        buscarVuelo.Destino = dto.Destino;
                        buscarVuelo.FechaInicio = dto.FechaInicio;
                        buscarVuelo.FechaFin = dto.FechaFin;
                        buscarVuelo.Origen = dto.Origen;
                        _Respuesta.Data = await _vueloApplication.BuscarVuelos(buscarVuelo);
                        _Respuesta.Exito = 1;
                    }
                    else
                    {
                        _Respuesta.Mensaje = "La fecha final debe ser mayor a la inicial";
                    }
                }
                else
                {
                    _Respuesta.Mensaje = "La fecha inicial debe ser mayor a la actual";
                }
            }
            catch (Exception ex)
            {
                _Respuesta.Mensaje = ex.Message;
            }
            return Ok(_Respuesta);
        }

    }
}
