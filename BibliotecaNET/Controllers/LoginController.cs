using BibliotecaNET.Models;
using Microsoft.AspNetCore.Mvc;
using ProyectoBiblioteca.Logica;
using System.Linq;

namespace ProyectoBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // GET: Login
        [HttpGet("Index")] // Especifica la ruta de acceso para esta acción
        public ActionResult Index()
        {
            return Ok("Bienvenido al Login"); // Cambia esto por tu lógica para mostrar la vista
        }

        [HttpPost("Index")] // Especifica la ruta de acceso para esta acción
        public ActionResult Index(string correo, string clave)
        {
            Persona? usuario = PersonaLogica.Instancia.Listar().FirstOrDefault(u => u.Correo == correo && u.Clave == clave && u.IdTipoPersona != 3);

            if (usuario == null)
            {
                return BadRequest("Usuario o contraseña incorrectos"); // Cambia esto por tu lógica de manejo de errores
            }

            return RedirectToAction("Index", "Admin"); // Cambia esto por tu lógica de redirección
        }
    }
}
