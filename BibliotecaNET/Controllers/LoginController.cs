using BibliotecaNET.Data;
using BibliotecaNET.Models;
using Microsoft.AspNetCore.Mvc;


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
        // GET: api/Auth/AllUsers
        [HttpGet("ConsultarUsuarios")]
        public ActionResult<IEnumerable<Persona>> ConsultarUsuarios()
        {
            var personas = _context.Personas.ToList();
            return Ok(personas);
        }

        [HttpPost("LoginAutenticacion")]
        public IActionResult LoginAutenticacion([FromBody] CredencialesUsuario credenciales)
        {
            var usuario = _context.Personas.FirstOrDefault(u => u.Correo == credenciales.Correo && u.Clave == credenciales.Clave && u.IdTipoPersona != 3);

            if (usuario == null)
            {
                return BadRequest("Usuario o contraseña incorrectos");
            }

            return Ok($"Bienvenido, {usuario.Nombre} {usuario.Apellido}!");
        }
    }
}
