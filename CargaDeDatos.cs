using System.Text.Json;
using System.Text.Json.Serialization;
namespace SistemaDeCadeteria
{
    public class CargaDeDatos
    {
        public List<Cadete>? CargarCadetes(string nombreDelArchivo)
        {            
            var data = File.ReadAllText(nombreDelArchivo);
            List<Cadete>? cadetes = JsonSerializer.Deserialize<List<Cadete>>(data);
            return cadetes;
        }

        public Cadeteria? CargarCadeteria(string nombreDelArchivo)
        {            
            var data = File.ReadAllText(nombreDelArchivo);
            Cadeteria? cadeteria = JsonSerializer.Deserialize<Cadeteria>(data);
            return cadeteria;
        }        
    }
}