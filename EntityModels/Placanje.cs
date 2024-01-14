using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Placanje")]
    public class Placanje
    {
        [Key]
        public int Id { get; set; }
        public string Grad { get; set; }
        [ForeignKey("KarticaId")]
        public int KarticaID { get; set; }
        public Kartica Kartica { get; set; }

        /*[ForeignKey("KursId")]
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }*/

        /*[ForeignKey("IspitId")]
        public int IspitId { get; set; }
        public Ispit Ispit { get; set; }*/

    }
}
