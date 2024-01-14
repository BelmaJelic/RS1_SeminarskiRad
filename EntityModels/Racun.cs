using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Racun")]
    public class Racun
    {
        public int Id { get; set; }
        public string KoriscnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
