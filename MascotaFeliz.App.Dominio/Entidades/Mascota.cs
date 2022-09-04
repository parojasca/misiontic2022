using System;
namespace MascotaFeliz.App.Dominio
{
    public class Mascota{
        public int id {get;set;}
        public string nombre {get;set;}
        public string color {get;set;}
        public string especie {get;set;}
        public string raza {get;set;}
        public Dueno dueno {get;set;}
        public Veterinario veterinario {get;set;}
        public Historia historia {get;set;}

    }
}