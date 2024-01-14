using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Grad")]
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
