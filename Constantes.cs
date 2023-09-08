namespace SistemaDeCadeteria
{
    public enum EstadoPedido
    {
        Pendiente, Creando, Embalando, Viajando, Realizado
    }

    public class Constantes
    {
        public const double VALOR_PEDIDO = 500;
        public const string NOMBRE_ARCHIVO_CADETERIA_JSON = "./cadeteria.json";
        public const string NOMBRE_ARCHIVO_CADETES_JSON = "./cadetes.json";
        public const string NOMBRE_ARCHIVO_CADETERIA_CSV = "./cadeteria.csv";
        public const string NOMBRE_ARCHIVO_CADETES_CSV = "./cadetes.csv";
    }
}