using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Profesor")]
    public class Profesor:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
