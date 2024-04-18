using System;
using System.Collections.Generic;

namespace BibliotecaNET.Models
{
    public partial class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int? IdEstadoPrestamo { get; set; }
        public int? IdPersona { get; set; }
        public int? IdLibro { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public DateTime? FechaConfirmacionDevolucion { get; set; }
        public string? EstadoEntregado { get; set; }
        public string? EstadoRecibido { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual EstadoPrestamo? IdEstadoPrestamoNavigation { get; set; }
        public virtual Libro? IdLibroNavigation { get; set; }
        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
