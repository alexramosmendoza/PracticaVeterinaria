using System;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;

//colecciones de datos, manejar de manera flexible las consultas en BD
using System.Collections.Generic;
//LINQ 
using System.Linq;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{

    public interface IRepositorioMascota
    {

       //firma de métodos del CRUD

        Mascota AddMascota(Mascota mascota);
        void DeleteMascota(int idMascota);

        Mascota GetMascota(int idMascota);

        Mascota UpdateMascota(Mascota mascota);

        IEnumerable<Mascota> GetAllMascotas();


    }

}