    using Microsoft.EntityFrameworkCore;
    using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public  class AppContext: DbContext
    {
        public DbSet< Persona> Personas  {get;set;}
        public DbSet<Veterinario> Veterinarios {get;set;}
        public DbSet<Dueno> Duenos  {get;set;}
        public DbSet<VisitaPyP> VisitasPyP {get;set;}
        public DbSet<Historia> Historias {get;set;}
        public DbSet<Mascota> Mascotas {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder
                .UseSqlServer("Data Source = PEDROROJAS\\SQLEXPRESS; Initial Catalog = MascotaFelizData; Integrated Security=True");
            }
        }
    }    
}