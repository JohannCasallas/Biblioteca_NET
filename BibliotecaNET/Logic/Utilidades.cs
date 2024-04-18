using System;
using System.IO;

namespace ProyectoBiblioteca.Logica
{
    public class Utilidades
    {
        public static string ConvertirBase64(string ruta)
        {
            try
            {
                if (!File.Exists(ruta))
                {
                    throw new FileNotFoundException("El archivo especificado no existe.", ruta);
                }

                byte[] bytes = File.ReadAllBytes(ruta);

                string base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error al convertir archivo a Base64: {ex.Message}");
                return null!;
            }
        }
    }
}
