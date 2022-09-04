using System;

namespace MascotaFeliz.App.Dominio
{
    public class VisitaPyP
    {
        public int id {get;set;} 
        public DateTime fechaVisita {get;set;} 
        public float temperatura {get;set;} 
        public float peso {get;set;} 
        public float frecuenciaRespiratoria {get;set;} 
        public float frecuenciaCardiaca {get;set;} 
        public string estadoAnimo {get;set;} 
        public int idVeterinario {get;set;} 
        public string recomendaciones {get;set;} 
        
    }
}