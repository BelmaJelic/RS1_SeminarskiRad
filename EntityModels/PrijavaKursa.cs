using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    public class PrijavaKursa
    {
        public int Id { get; set; }
        public DateTime DatumPrijave { get; set; }

        [ForeignKey(nameof(KorisnikId))]
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        [ForeignKey(nameof(KursId))]
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}
