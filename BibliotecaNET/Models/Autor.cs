using System;
using System.Collections.Generic;

namespace BibliotecaNET.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
