using BibliotecaNET.Data;
using BibliotecaNET.Models;
using System;

namespace ProyectoBiblioteca.Logica
{
    public class TipoPersonaLogica
    {
        private static TipoPersonaLogica instancia = null!;

        public TipoPersonaLogica()
        {

        }

        public static TipoPersonaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new TipoPersonaLogica();
                }

                return instancia;
            }
        }

        public List<TipoPersona> Listar()
        {
            List<TipoPersona> Lista = new List<TipoPersona>();
            try
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    Lista = contexto.TipoPersonas.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la lista de tipos de persona: " + ex.Message);
            }
            return Lista;
        }
    }
}
