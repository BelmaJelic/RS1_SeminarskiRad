using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.EntityModels;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
       
        public DbSet<Kurs> Kurs { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Ispit> Ispit { get; set; }
        public DbSet<PrijavaIspita> PrijavaIspita { get; set; }
        public DbSet<PrijavaKursa> PrijavaKursa { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<KategorijaKursa> KategorijaKursa { get; set; }
   
        public DbSet<Kartica> Kartica { get; set; }
        public DbSet<Placanje> Placanje { get; set; }
        public DbSet<CjenovnikKursa> CjenovnikKursa { get; set; }
        public DbSet<CjenovnikIspita> CjenovnikIspita { get; set; }

        public ApplicationDbContext(
           

           DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ovdje pise FluentAPI konfiguraciju

            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Nastavnik>().ToTable("Nastavnik");
        }
    }
}
