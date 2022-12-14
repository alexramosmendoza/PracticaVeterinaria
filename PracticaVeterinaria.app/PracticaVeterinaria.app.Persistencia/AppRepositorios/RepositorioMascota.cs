
using System;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;

//colecciones de datos, manejar de manera flexible las consultas en BD
using System.Collections.Generic;
//LINQ 
using System.Linq;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public class RepositorioMascota : IRepositorioMascota

    {

        // readonly -> permite definir un atributo solo para lectura
        private readonly AppContext _appContext;

        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        
        Mascota  IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        void  IRepositorioMascota.DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = _appContext.mascotas.FirstOrDefault(m => m.id == idMascota);

            if (mascotaEncontrada == null){
                return;
            }
            // si es null no continua con siguientes lineas
            _appContext.mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();

        }

        Mascota IRepositorioMascota.GetMascota(int idMascota)
        {
            return _appContext.mascotas.FirstOrDefault(m => m.id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota mascota){

            var mascotaEncontrada = _appContext.mascotas.FirstOrDefault(m => m.id == mascota.id);
            if(mascotaEncontrada!=null){

                mascota.id = mascotaEncontrada.id;
                mascota.color= mascotaEncontrada.color;
                mascota.especie = mascotaEncontrada.especie;
                mascota.nombre= mascotaEncontrada.nombre;
                mascota.raza = mascotaEncontrada.raza;
                mascota.propietario = mascotaEncontrada.propietario;
                _appContext.SaveChanges();
            }
            return mascota;

        }

        IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.mascotas;

        }
    }

}



