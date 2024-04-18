using BibliotecaNET.Models;
using BibliotecaNET.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectoBiblioteca.Logica
{
    public class LibroLogica
    {
        private static LibroLogica instancia = null;

        public LibroLogica() { }

        public static LibroLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new LibroLogica();
                }

                return instancia;
            }
        }

        public List<Libro> Listar()
        {
            List<Libro> rptListaLibro = new List<Libro>();
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext()) 
                {
                    rptListaLibro = contexto.Libros
                        .Include(l => l.IdAutorNavigation) 
                        .Include(l => l.IdCategoriaNavigation) 
                        .Include(l => l.IdEditorialNavigation) 
                        .ToList();

                    foreach (var libro in rptListaLibro)
                    {
                        Utilidades.ConvertirBase64(Path.Combine(libro.RutaPortada!, libro.NombrePortada!));
                        Path.GetExtension(libro.NombrePortada!).Replace(".", "");
                    }
                }
            }
            catch (Exception)
            {
                rptListaLibro = null!;
            }
            return rptListaLibro;
        }


        public int Registrar(Libro objeto)
        {
            int respuesta = 0;
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Libros.Add(objeto);
                    contexto.SaveChanges();
                    respuesta = objeto.IdLibro;
                }
            }
            catch (Exception)
            {
                respuesta = 0;
            }
            return respuesta;
        }

        public bool Modificar(Libro objeto)
        {
            bool respuesta = false;
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Entry(objeto).State = EntityState.Modified;
                    contexto.SaveChanges();
                    respuesta = true;
                }
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public bool ActualizarRutaImagen(Libro objeto)
        {
            bool respuesta = true;
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var libro = contexto.Libros.Find(objeto.IdLibro);
                    if (libro != null)
                    {
                        libro.NombrePortada = objeto.NombrePortada;
                        contexto.SaveChanges();
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var libro = contexto.Libros.Find(id);
                    if (libro != null)
                    {
                        contexto.Libros.Remove(libro);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
