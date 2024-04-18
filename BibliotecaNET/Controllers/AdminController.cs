using BibliotecaNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Acción para mostrar la página de inicio del panel de administración.
        /// </summary>
        /// <returns>La vista correspondiente al panel de administración.</returns>
        [HttpGet("Index")] // Especifica la ruta de acceso para esta acción
        public ActionResult Index()
        {
            var usuario = User.Identity?.Name;

            return Ok("Bienvenido al panel de administración"); // Cambia esto por tu lógica para mostrar la vista
        }

        /// <summary>
        /// Acción para cerrar la sesión del usuario.
        /// </summary>
        /// <returns>Redirige al usuario a la página de inicio de sesión.</returns>
        [HttpGet("CerrarSesion")] // Especifica la ruta de acceso para esta acción
        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Login"); // Cambia esto por tu lógica para cerrar sesión
        }
    }
}
