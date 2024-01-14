using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Korisnik")]
    public class Korisnik:KorisnickiNalog
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Slika { get; set; }
        [ForeignKey("GradId")]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
        
    }
}
