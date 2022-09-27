using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public interface IRepositorioVisita
    {
        Visita AddVisita(Visita visita);
        void DeleteVisita(int idVisita);

        Visita GetVisita(int idVisita);

        Visita UpdateVisita(Visita visita);

        IEnumerable<Visita> GetAllVisita();

        
    }



}