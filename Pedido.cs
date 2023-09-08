namespace SistemaDeCadeteria
{
    public class Pedido
    {
        private int numero;
        private string observacion;
        private Cliente cliente;
        private EstadoPedido estado;
        private Cadete cadete;
        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public EstadoPedido Estado { get => estado; }
        public Cadete Cadete { get => cadete; }

        public Pedido(int numero, string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
        {
            this.numero = numero;
            this.observacion = observacion;
            this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion); //Composición
            this.estado = EstadoPedido.Pendiente;            
        }        
        
        public void AsignarCadete (Cadete cadete)
        {
            this.cadete = cadete;
        }

        public string VerDireccionCliente()
        {
            return cliente.GetDatosDireccion();
        }

        public string VerDatosCliente()
        {
            return cliente.GetDatos();
        }

        public string GetInfo()
        {
            string info = $"Numero de pedido: {numero}\n";
            info += $"Observacion: {observacion}\n";
            info += cliente.GetInfo();
            info += $"Estado {estado.ToString()}\n";
            info += cadete.GetInfo();
            return info;
        }

        public void CambiarEstadoPedido(EstadoPedido nuevoEstado)
        {
            estado = nuevoEstado;
        }

        public bool EstaRealizado()
        {
            return estado == EstadoPedido.Realizado;
        }
    }
}