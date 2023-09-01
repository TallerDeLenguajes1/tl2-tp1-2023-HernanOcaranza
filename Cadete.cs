namespace SistemaDeCadeteria
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> pedidos;

        public int Id { get => id; }
        public string Nombre { get => nombre; }

        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> pedidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.pedidos = pedidos;
        }        

        public int CantidadDePedidosRealizados()
        {
            return pedidos.Select(p => p.Estado == EstadoPedido.Realizado).Count();
        }
        public double JornalACobrar()
        {
            return CantidadDePedidosRealizados() * Constantes.VALOR_PEDIDO;
        }

        public void AgregarPedido(Pedido nuevoPedido)
        {
            pedidos.Add(nuevoPedido);
        }

        public string GetInfoCadete()
        {
            string info = $"Nombre: {nombre}\n";
            info += $"Numero de cadete = {id}\n";
            info += $"Direccion: {direccion}\n";
            info += $"Telefono: {telefono}\n";
            return info;
        }
    }
}