namespace SistemaDeCadeteria
{
    public enum EstadoPedido
    {
        Pendiente, Creando, Embalando, Viajando, Realizado
    }

    public class Constantes
    {
        public const double VALOR_PEDIDO = 500;
        public const string NOMBRE_ARCHIVO_CADETERIA = "./cadeteria.json";
        public const string NOMBRE_ARCHIVO_CADETES = "./cadetes.json";
    }
}