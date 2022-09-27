
using System;
using Microsoft.EntityFrameworkCore;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;

        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {

            var veterinarioEncontrado = _appContext.veterinarios.FirstOrDefault(v => v.id == veterinario.id);
            if(veterinarioEncontrado!=null){

                veterinario.id = veterinarioEncontrado.id;
                veterinario.nombre = veterinarioEncontrado.nombre;
                veterinario.apellido = veterinarioEncontrado.apellido;
                veterinario.direccion = veterinarioEncontrado.direccion;
                veterinario.telefono = veterinarioEncontrado.telefono;
                veterinario.tarjetaProfesional = veterinarioEncontrado.tarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinario;
        }
        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.veterinarios.FirstOrDefault(ve => ve.id == idVeterinario);
            if (veterinarioEncontrado == null)
            {
                return;
            }
            _appContext.veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.veterinarios.FirstOrDefault(h => h.id == idVeterinario);
        }

        IEnumerable <Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return _appContext.veterinarios;
        }

    }   

}