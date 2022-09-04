using System;
using System.Collections.Generic;

namespace MascotaFeliz.App.Dominio
{
    public class Historia
    {
        public int id {get;set;}
        public DateTime fechaInicial {get;set;}
        public List<VisitaPyP> VisitasPyP {get;set;}
    }
}