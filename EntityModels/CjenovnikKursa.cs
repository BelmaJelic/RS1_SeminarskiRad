using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    public class CjenovnikKursa
    {
        [Key]
        public int Id { get; set; }
        public float Cijena { get; set; }
        public DateTime VrijemeTrajanja { get; set; }
        public string Opis { get; set; }
        [ForeignKey(nameof(Kurs))]
        public int KursId { get; set; } 
        public Kurs Kurs { get; set; }
    }
}
