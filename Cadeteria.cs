namespace SistemaDeCadeteria
{
    public class Cadeteria
    {
        private int autoIncremental;
        private string nombre;
        private string telefono;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
        {
            autoIncremental = 0;
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes;
            this.pedidos = new List<Pedido>();
        }

        public void CrearPedido(string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
        {
            var numeroPedido = autoIncremental;
            autoIncremental++;
            var nuevoPedido = new Pedido(numeroPedido, observacion, nombre, direccion, telefono, datosReferenciaDireccion);
            pedidos.Add(nuevoPedido);
        }

        public Pedido? GetPedidoPorId(int id)
        {
            return pedidos.Find(p => p.Numero == id);
        }

        public Cadete? GetCadetePorId(int id)
        {
            return cadetes.Find(p => p.Id == id);
        }

        public void AsignarPedidoACadete(Pedido pedido, Cadete cadete)
        {
            cadete.AgregarPedido(pedido);
        }

        public string ListarCadetes()
        {            
            string info = "Listado de Cadetes:\n";            
            foreach (var cadete in cadetes)
            {
                info += cadete.GetInfoCadete();
            }
            return info;
        }

        public string ListarPedidosSinAsignar()
        {
            string info = "Listado de Pedidos sin asignar:\n";
            foreach (var pedido in pedidos)
            {
                info += pedido.GetInfoPedido();
            }
            return info;
        }
    }
}