using BibliotecaNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ProyectoBiblioteca.Logica;
using BibliotecaNET.Data;



namespace ProyectoBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DB_BIBLIOTECAContext _context;

        public BibliotecaController(IWebHostEnvironment hostingEnvironment, DB_BIBLIOTECAContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        // GET: api/Biblioteca/Libros
        [HttpGet("Libros")]
        public ActionResult<IEnumerable<Libro>> GetLibros()
        {
            var libros = _context.Libros.ToList(); 
            return Ok(libros);
        }

        // GET: api/Biblioteca/Autores
        [HttpGet("Autores")]
        public ActionResult<IEnumerable<Autor>> GetAutores()
        {
            var autores = _context.Autors.ToList(); 
            return Ok(autores);
        }

        // GET: api/Biblioteca/Editoriales
        [HttpGet("Editoriales")]
        public ActionResult<IEnumerable<Editorial>> GetEditoriales()
        {
            var editoriales = _context.Editorials.ToList(); 
            return Ok(editoriales); 
        }

        // GET: api/Biblioteca/Categorias
        [HttpGet("Categorias")]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            var categorias = _context.Categoria.ToList(); 
            return Ok(categorias); 
        }

        [HttpGet("ListarCategoria")]
        public ActionResult<IEnumerable<Categoria>> ListarCategoria()
        {
            List<Categoria> oLista = CategoriaLogica.Instancia.Listar();
            return Ok(new { data = oLista });
        }

        [HttpPost("GuardarCategoria")]
        public ActionResult GuardarCategoria([FromBody] Categoria objeto)
        {
            bool respuesta = (objeto.IdCategoria == 0) ? CategoriaLogica.Instancia.Registrar(objeto) : CategoriaLogica.Instancia.Modificar(objeto);
            return Ok(new { resultado = respuesta });
        }

        [HttpPost("EliminarCategoria")]
        public ActionResult EliminarCategoria([FromBody] Categoria objeto)
        {
            bool respuesta = CategoriaLogica.Instancia.Eliminar(objeto.IdCategoria);
            return Ok(new { resultado = respuesta });
        }


        [HttpGet("ListarEditorial")]
        public ActionResult<IEnumerable<Editorial>> ListarEditorial()
        {
            List<Editorial> oLista = EditorialLogica.Instancia.Listar();
            return Ok(new { data = oLista });
        }

        [HttpPost("GuardarEditorial")]
        public ActionResult GuardarEditorial([FromBody] Editorial objeto)
        {
            bool respuesta = (objeto.IdEditorial == 0) ? EditorialLogica.Instancia.Registrar(objeto) : EditorialLogica.Instancia.Modificar(objeto);
            return Ok(new { resultado = respuesta });
        }

        [HttpPost("EliminarEditorial")]
        public ActionResult EliminarEditorial(int id)
        {
            bool respuesta = EditorialLogica.Instancia.Eliminar(id);
            return Ok(new { resultado = respuesta });
        }

        [HttpGet("ListarAutor")]
        public ActionResult<IEnumerable<Autor>> ListarAutor()
        {
            List<Autor> oLista = AutorLogica.Instancia.Listar();
            return Ok(new { data = oLista });
        }

        [HttpPost("GuardarAutor")]
        public ActionResult GuardarAutor([FromBody] Autor objeto)
        {
            bool respuesta = (objeto.IdAutor == 0) ? AutorLogica.Instancia.Registrar(objeto) : AutorLogica.Instancia.Modificar(objeto);
            return Ok(new { resultado = respuesta });
        }

        [HttpPost("EliminarAutor")]
        public ActionResult EliminarAutor(int id)
        {
            bool respuesta = AutorLogica.Instancia.Eliminar(id);
            return Ok(new { resultado = respuesta });
        }

        [HttpGet("ListarLibro")]
        public ActionResult<IEnumerable<Libro>> ListarLibro()
        {
            List<Libro> oLista = LibroLogica.Instancia.Listar();
            return Ok(new { data = oLista });
        }

        [HttpPost("GuardarLibro")]
        public ActionResult GuardarLibro([FromBody] string objeto, IFormFile imagenArchivo)
        {
            Response oresponse = new Response() { resultado = true, mensaje = "" };

            try
            {
                Libro? oLibro = JsonSerializer.Deserialize<Libro>(objeto);

                string guardarEnRuta = Path.Combine(_hostingEnvironment.WebRootPath, "ruta_imagenes_libros");
                oLibro!.RutaPortada = guardarEnRuta;
                oLibro.NombrePortada = "";

                if (!Directory.Exists(guardarEnRuta))
                {
                    Directory.CreateDirectory(guardarEnRuta);
                }

                if (oLibro.IdLibro == 0)
                {
                    int id = LibroLogica.Instancia.Registrar(oLibro);
                    oLibro.IdLibro = id;
                    oresponse.resultado = oLibro.IdLibro == 0 ? false : true;
                }
                else
                {
                    oresponse.resultado = LibroLogica.Instancia.Modificar(oLibro);
                }

                if (imagenArchivo != null && oLibro.IdLibro != 0)
                {
                    string extension = Path.GetExtension(imagenArchivo.FileName);
                    string rutaImagen = Path.Combine(guardarEnRuta, $"{oLibro.IdLibro}{extension}");
                    oLibro.NombrePortada = $"{oLibro.IdLibro}{extension}";

                    using (var stream = new FileStream(rutaImagen, FileMode.Create))
                    {
                        imagenArchivo.CopyTo(stream);
                    }

                    oresponse.resultado = LibroLogica.Instancia.ActualizarRutaImagen(oLibro);
                }
            }
            catch (Exception e)
            {
                oresponse.resultado = false;
                oresponse.mensaje = e.Message;
            }

            return Ok(oresponse);
        }

        [HttpPost("EliminarLibro")]
        public ActionResult EliminarLibro(int id)
        {
            bool respuesta = LibroLogica.Instancia.Eliminar(id);
            return Ok(new { resultado = respuesta });
        }

        [HttpGet("ListarTipoPersona")]
        public ActionResult<IEnumerable<TipoPersona>> ListarTipoPersona()
        {
            List<TipoPersona> oLista = TipoPersonaLogica.Instancia.Listar();
            return Ok(new { data = oLista });
        }

        [HttpGet("ListarPersona")]
        public ActionResult<IEnumerable<Persona>> ListarPersona()
        {
            List<Persona> oLista = PersonaLogica.Instancia.Listar();
            return Ok(new { data = oLista });
        }

        [HttpPost("GuardarPersona")]
        public ActionResult GuardarPersona(Persona objeto)
        {
            bool respuesta = (objeto.IdPersona == 0) ? PersonaLogica.Instancia.Registrar(objeto) : PersonaLogica.Instancia.Modificar(objeto);
            return Ok(new { resultado = respuesta });
        }

        [HttpPost("EliminarPersona")]
        public ActionResult EliminarPersona(int id)
        {
            bool respuesta = PersonaLogica.Instancia.Eliminar(id);
            return Ok(new { resultado = respuesta });
        }

    }
    public class Response
    {

        public bool resultado { get; set; }
        public string? mensaje { get; set; }
    }
}