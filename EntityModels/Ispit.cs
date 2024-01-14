using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    
    public class Ispit
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [ForeignKey(nameof(KursId))]
        public Kurs Kurs { get; set; }
        public int KursId { get; set; }
        public DateTime DatumIspita { get; set; }

    }
}
