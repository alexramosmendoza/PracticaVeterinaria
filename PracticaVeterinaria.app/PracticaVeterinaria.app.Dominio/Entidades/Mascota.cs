using System;

namespace PracticaVeterinaria.app.Dominio
{
    public class Mascota
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public Propietario propietario { get; set; }

    }
}