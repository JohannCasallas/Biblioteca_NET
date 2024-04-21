namespace BibliotecaNET.Models
{
    public class RespuestaModel
    {
        public string? Mensaje { get; set; } 
        public bool Exito { get; set; }
        public object? Datos { get; set; }
    }
}
