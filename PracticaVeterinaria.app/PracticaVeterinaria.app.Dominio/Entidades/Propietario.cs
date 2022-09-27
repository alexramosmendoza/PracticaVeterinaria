using System;

namespace PracticaVeterinaria.app.Dominio
{
    public class Propietario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
    }
}
