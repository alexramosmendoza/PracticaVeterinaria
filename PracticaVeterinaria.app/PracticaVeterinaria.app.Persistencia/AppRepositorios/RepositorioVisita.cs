
using System;
using Microsoft.EntityFrameworkCore;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;

        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        Visita IRepositorioVisita.AddVisita(Visita visita)
        {
            var visitaAdicionada = _appContext.visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaAdicionada.Entity;

        }

        Visita IRepositorioVisita.UpdateVisita(Visita visita)
        {

            var visitaEncontrada = _appContext.visitas.FirstOrDefault(vi => vi.id == visita.id);
            if(visitaEncontrada!=null){

                visita.id = visitaEncontrada.id;
                visita.temperatura = visitaEncontrada.temperatura;
                visita.peso = visitaEncontrada.peso;
                visita.frecRespiratoria = visitaEncontrada.frecRespiratoria;
                visita.frecCardiaca = visitaEncontrada.frecCardiaca;
                visita.estadoAnimo = visitaEncontrada.estadoAnimo;
                visita.fechaVisita = visitaEncontrada.fechaVisita;
                visita.recomendaciones = visitaEncontrada.recomendaciones;
                visita.formulaMedica = visitaEncontrada.formulaMedica;
                visita.historiaClinica = visitaEncontrada.historiaClinica;
                visita.veterinario = visitaEncontrada.veterinario;
                _appContext.SaveChanges();
            }
            return visita;
        }
        void IRepositorioVisita.DeleteVisita(int idVisita)
        {
            var visitaEncontrada = _appContext.visitas.FirstOrDefault(ve => ve.id == idVisita);
            if (visitaEncontrada == null)
            {
                return;
            }
            _appContext.visitas.Remove(visitaEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Visita> IRepositorioVisita.GetAllVisita()
        {
            return _appContext.visitas;
        }

        Visita IRepositorioVisita.GetVisita(int idVisita)
        {
            return _appContext.visitas.FirstOrDefault(h => h.id == idVisita);
        }

      

    }

}