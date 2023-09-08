namespace SistemaDeCadeteria
{
    public class Cadeteria
    {
        private readonly IAccesoADatos _accesoADatos;
        private int autoIncremental;
        private string nombre;
        private string telefono;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        public Cadeteria(IAccesoADatos accesoADatos, string nombre, string telefono, List<Cadete> cadetes)
        {
            this._accesoADatos = accesoADatos;
            autoIncremental = 0;
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes;
            this.pedidos = new List<Pedido>();
        }

        public void CargarDatos(string route)
        {
            var cadetesGuardados = _accesoADatos.CargarCadetes(route);
            var cadeteriaGuardada = _accesoADatos.CargarCadeteria(route);
            autoIncremental = cadeteriaGuardada.autoIncremental;
            nombre = cadeteriaGuardada.nombre;
            telefono = cadeteriaGuardada.telefono;
            cadetes = cadetesGuardados;
            pedidos = cadeteriaGuardada.pedidos;
        }

        public void CrearPedido(
            string observacion, 
            string nombre, 
            string direccion, 
            string telefono, 
            string datosReferenciaDireccion)
        {
            var numeroPedido = autoIncremental;
            autoIncremental++;
            var nuevoPedido = new Pedido(
                numeroPedido, 
                observacion, 
                nombre, 
                direccion, 
                telefono, 
                datosReferenciaDireccion);
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
                info += cadete.GetInfo();
            }
            return info;
        }

        public string ListarPedidos()
        {
            string info = "Listado de Pedidos:\n";
            foreach (var pedido in pedidos)
            {
                info += pedido.GetInfo();
            }
            return info;
        }

        public List<Pedido> GetListadoDePedidosDeUnCadete(int idCadete)
        {
            return pedidos.Where(p => p.Cadete.Id == idCadete).ToList();
        }        

        public double JornalACobrar(int idCadete)
        {            
            return GetListadoDePedidosDeUnCadete(idCadete)
                .Where(p => p.EstaRealizado()).Count() * Constantes.VALOR_PEDIDO;            
        }

        public List<Pedido> GetPedidosSinAsignar()
        {
            return pedidos.Where(p => p.Cadete == null).ToList();
        }

        public string GetInfo()
        {
            string info = "Información de la cadeteria:\n";
            info += $"Nombre {nombre}\n";
            info += $"Telefono {telefono}\n";
            return info;
        }
    }
}