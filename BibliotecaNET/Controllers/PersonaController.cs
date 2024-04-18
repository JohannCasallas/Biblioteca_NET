using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProyectoBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        // GET: api/Persona/Usuarios
        [HttpGet("Usuarios")]
        public ActionResult Usuarios()
        {
            return Ok("Listado de usuarios"); // Cambia esto por tu lógica para devolver el listado de usuarios
        }

        // GET: api/Persona/Lectores
        [HttpGet("Lectores")]
        public ActionResult Lectores()
        {
            return Ok("Listado de lectores"); // Cambia esto por tu lógica para devolver el listado de lectores
        }
    }
}
