using BibliotecaNET.Data;
using BibliotecaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoBiblioteca.Logica
{
    public class EditorialLogica
    {
        private static EditorialLogica? instancia = null;

        public EditorialLogica() { }

        public static EditorialLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new EditorialLogica();
                }

                return instancia;
            }
        }

        public bool Registrar(Editorial oEditorial)
        {
            bool respuesta = true;
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Editorials.Add(oEditorial);
                    contexto.SaveChanges();
                }
            }
            return respuesta;
        }

        public bool Modificar(Editorial oEditorial)
        {
            bool respuesta = true;
            {
                using (var contexto = new DB_BIBLIOTECAContext()) 
                {
                    var editorialExistente = contexto.Editorials.Find(oEditorial.IdEditorial);

                    if (editorialExistente != null)
                    {
                        contexto.Entry(editorialExistente).CurrentValues.SetValues(oEditorial);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        respuesta = false; 
                    }
                }
            }
            return respuesta;
        }

        public List<Editorial> Listar()
        {
            List<Editorial> Lista = new List<Editorial>();
            {
                using (var contexto = new DB_BIBLIOTECAContext()) 
                {
                    Lista = contexto.Editorials.ToList();
                }
            }
            return Lista;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            {
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var editorialAEliminar = contexto.Editorials.Find(id);

                    if (editorialAEliminar != null)
                    {
                        contexto.Editorials.Remove(editorialAEliminar);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            return respuesta;
        }
    }
}
