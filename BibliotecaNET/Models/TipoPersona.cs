using System;
using System.Collections.Generic;

namespace BibliotecaNET.Models
{
    public partial class TipoPersona
    {
        public TipoPersona()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdTipoPersona { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
