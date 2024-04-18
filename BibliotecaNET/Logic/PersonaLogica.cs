using BibliotecaNET.Data;
using BibliotecaNET.Models;
using Microsoft.EntityFrameworkCore;


namespace ProyectoBiblioteca.Logica
{
    public class PersonaLogica
    {
        private static PersonaLogica instancia = null!;

        public PersonaLogica()
        {

        }

        public static PersonaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new PersonaLogica();
                }

                return instancia;
            }
        }

        public bool Registrar(Persona objeto)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Personas.Add(objeto);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(Persona objeto)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Entry(objeto).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Persona> Listar()
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    return contexto.Personas.Include("TipoPersona").ToList();
                }
            }
            catch (Exception)
            {
                return new List<Persona>();
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var persona = contexto.Personas.Find(id);
                    if (persona != null)
                    {
                        contexto.Personas.Remove(persona);
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
