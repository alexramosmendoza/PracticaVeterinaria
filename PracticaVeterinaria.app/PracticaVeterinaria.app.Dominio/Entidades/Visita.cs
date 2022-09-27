using System;
namespace PracticaVeterinaria.app.Dominio
{
    public class Visita
    {
        public int id{get; set;}
        public string temperatura{get;set;}
        public string peso{get;set;}
        public int frecRespiratoria{get;set;}
        public int frecCardiaca{get;set;}
        public string estadoAnimo{get;set;}
        public string fechaVisita{get; set;}
        public string recomendaciones{get;set;}
        public string formulaMedica{get;set;}
        public HistoriaClinica historiaClinica {get; set;}
        public Veterinario veterinario {get;set;}
    }
}