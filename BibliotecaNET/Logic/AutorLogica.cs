using BibliotecaNET.Data;
using BibliotecaNET.Models;


namespace ProyectoBiblioteca.Logica
{
    public class AutorLogica
    {

        private static AutorLogica? instancia = null;

        public AutorLogica()
        {

        }

        public static AutorLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new AutorLogica();
                }

                return instancia;
            }
        }

        public bool Registrar(Autor oAutor)
        {
            bool respuesta = true;
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Autors.Add(oAutor);
                    contexto.SaveChanges();
                }
            
            return respuesta;
        }


        public bool Modificar(Autor oAutor)
        {
            bool respuesta = true;
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var autorExistente = contexto.Autors.Find(oAutor.IdAutor);

                    if (autorExistente != null)
                    {
                        contexto.Entry(autorExistente).CurrentValues.SetValues(oAutor);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        respuesta = false; 
                    }
                }
            return respuesta;
        }


        public List<Autor> Listar()
        {
            List<Autor> Lista = new List<Autor>();
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    Lista = contexto.Autors.ToList();
                }
            return Lista;
        }


        public bool Eliminar(int id)
        {
            bool respuesta = true;
            
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var autorAEliminar = contexto.Autors.Find(id);

                    if (autorAEliminar != null)
                    {
                        contexto.Autors.Remove(autorAEliminar);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            return respuesta;
            
        }

    }
}