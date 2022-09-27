using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public interface IRepositorioHistoriaClinica
    {
        HistoriaClinica AddHistoriaClinica(HistoriaClinica historiaClinica);
        void DeleteHistoriaClinica(int idHistoriaClinica);

        HistoriaClinica GetHistoriaClinica(int idHistoriaClinica);

        HistoriaClinica UpdateHistoriaClinica(HistoriaClinica historiaClinica);

        IEnumerable<HistoriaClinica> GetAllHistoriaClinica();

    }

}