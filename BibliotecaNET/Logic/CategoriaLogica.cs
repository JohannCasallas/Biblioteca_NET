using BibliotecaNET.Data;
using BibliotecaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoBiblioteca.Logica
{
    public class CategoriaLogica
    {
        private static CategoriaLogica? instancia = null;

        public CategoriaLogica() { }

        public static CategoriaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CategoriaLogica();
                }

                return instancia;
            }
        }

        public bool Registrar(Categoria oCategoria)
        {
            bool respuesta = true;
            { 
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    contexto.Categoria.Add(oCategoria);
                    contexto.SaveChanges();
                }
            }
            return respuesta;
        }

        public bool Modificar(Categoria oCategoria)
        {
            bool respuesta = true;
            { 
           
                using (var contexto = new DB_BIBLIOTECAContext())
                {
                    var categoriaExistente = contexto.Categoria.Find(oCategoria.IdCategoria);

                    if (categoriaExistente != null)
                    {

                        contexto.Entry(categoriaExistente).CurrentValues.SetValues(oCategoria);
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

        public List<Categoria> Listar()
        {
            List<Categoria> Lista = new List<Categoria>();
            {
                using (var contexto = new DB_BIBLIOTECAContext()) 
                {
                    Lista = contexto.Categoria.ToList();
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
                    var categoriaAEliminar = contexto.Categoria.Find(id);

                    if (categoriaAEliminar != null)
                    {
                        contexto.Categoria.Remove(categoriaAEliminar);
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
