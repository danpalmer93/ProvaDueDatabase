using Microsoft.EntityFrameworkCore;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Data
{
    public class ProvaDueContext : DbContext
    {
        public ProvaDueContext (DbContextOptions<ProvaDueContext> options) : base(options)
        {
            
        }

        public DbSet<Figura> Figure { get; set; }  
        public DbSet<Domanda> Domande { get; set; }
        public DbSet<FigureDomande> FigureDomande { get; set; }
        public DbSet<Risposta> Risposta { get; set; }
        public DbSet<Utente> Utente { get; set; }
    }
}
