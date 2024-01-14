using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace WebApplication1.EntityModels
{
     [Table("Kartica")]

    public class Kartica
    {
        [Key]
        public int Id { get; set; }
        public long BrojKartice { get; set; }
        [ForeignKey("KorisnikId")]
        public int KorisnikId { get; set; }
        public Korisnik korisnik { get; set; }
    }
}
