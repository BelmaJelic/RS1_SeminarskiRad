using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EntityModels
{
    public class CjenovnikIspita
    {
        [Key]
        public int Id { get; set; }
        public float Cijena { get; set; }
        public DateTime VrijemeTrajanja { get; set; }
        public string Opis { get; set; }
        [ForeignKey(nameof(Ispit))]
        public int IspitId { get; set; }
        public Ispit Ispit { get; set; }
    }
}
