using BibliotecaNET.Data;
using BibliotecaNET.Models;
using Microsoft.EntityFrameworkCore;


namespace ProyectoBiblioteca.Logica
{
    public class PrestamoLogica
    {
        private static PrestamoLogica instancia = null;

        public PrestamoLogica()
        {

        }

        public static PrestamoLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new PrestamoLogica();
                }

                return instancia;
            }
        }

        public bool Registrar(Prestamo objeto)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Prestamos.Add(objeto);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Existe(Prestamo objeto)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    return contexto.Prestamos.Any(p => p.IdPersona == objeto.IdPersona && p.IdLibro == objeto.IdLibro);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EstadoPrestamo> ListarEstados()
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    return contexto.EstadoPrestamos.ToList();
                }
            }
            catch (Exception)
            {
                return new List<EstadoPrestamo>();
            }
        }

        public List<Prestamo> Listar(int idestadoprestamo, int idpersona)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    return contexto.Prestamos
                        .Where(p => (idestadoprestamo == 0 || p.IdEstadoPrestamo == idestadoprestamo) &&
                                    (idpersona == 0 || p.IdPersona == idpersona))
                        .Include(p => p.IdEstadoPrestamoNavigation)
                        .Include(p => p.IdPersonaNavigation)
                        .Include(p => p.IdLibroNavigation)
                        .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Prestamo>();
            }
        }

        public bool Devolver(string estadorecibido, int idprestamo)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var prestamo = contexto.Prestamos.Find(idprestamo);
                    if (prestamo != null)
                    {
                        prestamo.IdEstadoPrestamo = 2;
                        prestamo.FechaConfirmacionDevolucion = DateTime.Now;
                        prestamo.EstadoRecibido = estadorecibido;
                        contexto.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
