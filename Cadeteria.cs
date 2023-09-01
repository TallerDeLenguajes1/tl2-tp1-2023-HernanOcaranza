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

        public Pedido GetPedidoPorId(int id)
        {
            return pedidos.Find(p => p.Numero == id);
        }

        public Cadete GetCadetePorId(int id)
        {
            return cadetes.Find(p => p.Id == id);
        }

        public bool PerteneceACadeteria(Cadete cadete)
        {
            return cadetes.Find(c => c == cadete) != null;
        }

        public bool PerteneceACadeteria(Pedido pedido)
        {
            return pedidos.Find(p => p == pedido) != null;
        }        

        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            Cadete cadete = GetCadetePorId(idCadete);
            Pedido pedido = GetPedidoPorId(idPedido);
            pedido.AsignarCadete(cadete);            
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

        public string ListarPedidos()
        {
            string info = "Listado de Pedidos:\n";
            foreach (var pedido in pedidos)
            {
                info += pedido.GetInfoPedido();
            }
            return info;
        }

        public List<Pedido> GetListadoDePedidosDeUnCadete(Cadete cadete)
        {
            return pedidos.Where(p => p.Cadete == cadete).ToList();
        }        

        public double JornalACobrar(int idCadete)
        {
            Cadete cadete = GetCadetePorId(idCadete);
            return GetListadoDePedidosDeUnCadete(cadete).Where(p => p.EstaRealizado()).Count() * Constantes.VALOR_PEDIDO;            
        }
    }
}