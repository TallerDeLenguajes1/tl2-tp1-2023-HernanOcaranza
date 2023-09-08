using System.Text.Json;
using System.Text.Json.Serialization;
namespace SistemaDeCadeteria
{
    public interface IAccesoADatos
    {
        public List<Cadete> CargarCadetes(string route);

        public Cadeteria CargarCadeteria(string route);
    }

    public class AccesoADatosJson : IAccesoADatos
    {
        public List<Cadete> CargarCadetes(string route)
        {
            var data = File.ReadAllText(route);
            List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(data);
            return cadetes;
        }

        public Cadeteria CargarCadeteria(string route)
        {
            var data = File.ReadAllText(route);
            Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(data);
            return cadeteria;
        }        
    }

    public class AccesoADatosCsv : IAccesoADatos
    {
        public Cadeteria CargarCadeteria(string route)
        {
            throw new NotImplementedException();
        }

        public List<Cadete> CargarCadetes(string route)
        {
            throw new NotImplementedException();
        }
    }
}