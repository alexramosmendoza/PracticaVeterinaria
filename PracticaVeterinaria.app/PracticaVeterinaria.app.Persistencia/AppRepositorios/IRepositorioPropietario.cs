

using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;

namespace PracticaVeterinaria.app.Persistencia.AppRepositorios
{
    public interface IRepositorioPropietario
    {
        // Implementar la firma de los métodos del CRUD
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario);

        void DeletePropietario(int idPropietario);

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Propietario> GetAllPropietarios();

        Propietario GetPropietario(int idPropietario);
    }
}