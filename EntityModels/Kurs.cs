using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Kurs")]
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public string Vrsta { get; set; }
        public int BrojCasova { get; set; }
        public string VrijemeTrajanja { get; set; }
        public string ImeProfesora { get; set; }
    }
}
