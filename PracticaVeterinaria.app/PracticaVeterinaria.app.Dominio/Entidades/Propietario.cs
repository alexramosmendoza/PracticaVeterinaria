using System;
using System.ComponentModel.DataAnnotations;

namespace PracticaVeterinaria.app.Dominio
{
    public class Propietario
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre del Propietario")]
        public string nombre { get; set; }
         [Display(Name = "Apellido del Propietario")]
        public string apellido { get; set; }
         [Display(Name = "Direcciòn del Propietario")]
        public string direccion { get; set; }
         [Display(Name = "Telèfono del Propietario")]
        public int telefono { get; set; }
         [Display(Name = "Correo del Propietario")]
        public string correo { get; set; }
    }
}
