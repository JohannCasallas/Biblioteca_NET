using BibliotecaNET.Data;
using BibliotecaNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoBiblioteca.Controllers
{
 
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DB_BIBLIOTECAContext _context;

        public LoginController(DB_BIBLIOTECAContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Consulta todos los usuarios registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Persona que representan a los usuarios.</returns>
        [HttpGet("ConsultarUsuarios")]
        public ActionResult<IEnumerable<Persona>> ConsultarUsuarios()
        {
            var personas = _context.Personas.ToList();
            return Ok(personas);
        }

        /// <summary>
        /// Autentica a un usuario utilizando las credenciales proporcionadas.
        /// </summary>
        /// <param name="credenciales">Credenciales del usuario para autenticación.</param>
        /// <returns>Respuesta de autenticación con un mensaje y un indicador de éxito.</returns>
        [HttpPost("LoginAutenticacion")]
        public IActionResult LoginAutenticacion([FromBody] CredencialesUsuario credenciales)
        {
            var usuario = _context.Personas.FirstOrDefault(u => u.Correo == credenciales.Correo && u.Clave == credenciales.Clave && u.IdTipoPersona != 3);

            if (usuario == null)
            {
                return Ok(new RespuestaModel { Mensaje = "Usuario o contraseña incorrectos", Exito = false });
            }

            return Ok(new RespuestaModel { Mensaje = $"Bienvenido, {usuario.Nombre} {usuario.Apellido}!", Exito = true });
        }
    }
}
