using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Administrator")]
    public class Administrator
    {
        public int Id { get; set; }
        public string Ime { get; set; }
    }
}
