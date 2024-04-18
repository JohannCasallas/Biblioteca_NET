using BibliotecaNET.Models;
using Microsoft.AspNetCore.Mvc;
using ProyectoBiblioteca.Logica;
using System.Collections.Generic;

namespace ProyectoBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        // GET: api/Prestamo/Registrar
        [HttpGet("Registrar")]
        public ActionResult Registrar()
        {
            return Ok("Registrar prestamo"); // Cambia esto por tu lógica para registrar un préstamo
        }

        // GET: api/Prestamo/Consultar
        [HttpGet("Consultar")]
        public ActionResult Consultar()
        {
            return Ok("Consultar prestamo"); // Cambia esto por tu lógica para consultar un préstamo
        }

        // POST: api/Prestamo/GuardarPrestamos
        [HttpPost("GuardarPrestamos")]
        public ActionResult GuardarPrestamos(Prestamo objeto)
        {
            bool _respuesta = false;
            string _mensaje = string.Empty;

            _respuesta = PrestamoLogica.Instancia.Existe(objeto);

            if (_respuesta)
            {
                _respuesta = false;
                _mensaje = "El lector ya tiene un prestamo pendiente con el mismo libro";
            }
            else
            {
                _respuesta = PrestamoLogica.Instancia.Registrar(objeto);
                _mensaje = _respuesta ? "Registro completo" : "No se pudo registrar";
            }

            return Ok(new { resultado = _respuesta, mensaje = _mensaje });
        }

        // GET: api/Prestamo/ListarEstados
        [HttpGet("ListarEstados")]
        public ActionResult ListarEstados()
        {
            List<EstadoPrestamo> oLista = PrestamoLogica.Instancia.ListarEstados();
            return Ok(new { data = oLista });
        }

        // GET: api/Prestamo/Listar
        [HttpGet("Listar")]
        public ActionResult Listar(int idestadoprestamo, int idpersona)
        {
            List<Prestamo> oLista = PrestamoLogica.Instancia.Listar(idestadoprestamo, idpersona);
            return Ok(new { data = oLista });
        }

        // POST: api/Prestamo/Devolver
        [HttpPost("Devolver")]
        public ActionResult Devolver(string estadorecibido, int idprestamo)
        {
            bool respuesta = PrestamoLogica.Instancia.Devolver(estadorecibido, idprestamo);
            return Ok(new { resultado = respuesta });
        }
    }
}
