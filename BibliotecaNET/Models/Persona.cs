using System;
using System.Collections.Generic;

namespace BibliotecaNET.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public string? Codigo { get; set; }
        public int? IdTipoPersona { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual TipoPersona? IdTipoPersonaNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
