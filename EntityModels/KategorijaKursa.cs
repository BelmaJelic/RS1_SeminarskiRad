using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("KategorijaKursa")]
    public class KategorijaKursa
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

    }
}
