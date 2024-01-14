using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{

    public class PrijavaIspita
    {
        public int Id { get; set; }
        public DateTime DatumPrijave { get; set; }

        [ForeignKey(nameof(KorisnikId))]
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        [ForeignKey(nameof(IspitId))]
        public int IspitId { get; set; }
        public Ispit Ispit { get; set; }
    }
}
