namespace SistemaDeCadeteria
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;        

        public int Id { get => id; }
        public string Nombre { get => nombre; }

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;            
        }                            

        public string GetInfo()
        {
            string info = $"Nombre: {nombre}\n";
            info += $"Numero de cadete = {id}\n";
            info += $"Direccion: {direccion}\n";
            info += $"Telefono: {telefono}\n";
            return info;
        }
    }
}