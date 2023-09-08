namespace SistemaDeCadeteria
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;
        public string Nombre { get => nombre; }
        public string Telefono { get => telefono; }
        public string Direccion { get => direccion; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; }

        public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }

        public string GetDatos()
        {            
            string info = $"Nombre: {nombre}\n";
            info += $"Telefono: {telefono}\n";
            return info;
        }

        public string GetDatosDireccion()
        {            
            string info = $"Direccion: {direccion}\n";
            info += $"Datos de referencia: {datosReferenciaDireccion}\n";
            return info;
        }

        public string GetInfo()
        {
            string info = GetDatos();
            info += GetDatosDireccion();
            return info;
        }
    }
}