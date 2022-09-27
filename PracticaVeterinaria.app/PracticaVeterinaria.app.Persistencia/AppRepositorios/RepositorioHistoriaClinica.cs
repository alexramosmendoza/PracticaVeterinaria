
using System;
using Microsoft.EntityFrameworkCore;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public class RepositorioHistoriaClinica : IRepositorioHistoriaClinica
    {
        private readonly AppContext _appContext;

        public RepositorioHistoriaClinica(AppContext appContext)
        {
            _appContext = appContext;
        }

        HistoriaClinica IRepositorioHistoriaClinica.AddHistoriaClinica(HistoriaClinica historiaClinica)
        {
            var historiaClinicaAdicionada = _appContext.historiasclinicas.Add(historiaClinica);
            _appContext.SaveChanges();
            return historiaClinicaAdicionada.Entity;

        }

        HistoriaClinica IRepositorioHistoriaClinica.UpdateHistoriaClinica(PracticaVeterinaria.app.Dominio.HistoriaClinica historiaClinica)
        {

            var historiaClinicaEncontrada = _appContext.historiasclinicas.FirstOrDefault(h => h.id == historiaClinica.id);
            if(historiaClinicaEncontrada!=null){

                historiaClinica.id = historiaClinicaEncontrada.id;
                historiaClinica.mascota= historiaClinicaEncontrada.mascota;
                historiaClinica.fechaDeCreacion = historiaClinicaEncontrada.fechaDeCreacion;
                _appContext.SaveChanges();
            }
            return historiaClinica;
        }
        void IRepositorioHistoriaClinica.DeleteHistoriaClinica(int idHistoriaClinica)
        {
            var historiaClinicaEncontrada = _appContext.historiasclinicas.FirstOrDefault(h => h.id == idHistoriaClinica);
            if (historiaClinicaEncontrada == null)
            {
                return;
            }
            _appContext.historiasclinicas.Remove(historiaClinicaEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<HistoriaClinica> IRepositorioHistoriaClinica.GetAllHistoriaClinica()
        {
            return _appContext.historiasclinicas;
        }

        HistoriaClinica IRepositorioHistoriaClinica.GetHistoriaClinica(int idHistoriaClinica)
        {
            return _appContext.historiasclinicas.FirstOrDefault(h => h.id == idHistoriaClinica);
        }

        

        
    
    }


}