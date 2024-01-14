using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebApplication1.EntityModels
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        [JsonIgnore]
        public string Lozinka { get; set; }
        [JsonIgnore]
        public string SlikaKorisnika { get; set; }
        [JsonIgnore]
        public Korisnik korisnik => this as Korisnik;
        [JsonIgnore]
        public Profesor profesor => this as Profesor;
        [JsonIgnore]
        public bool isProfesor => profesor != null;
        public bool isKorisnik => korisnik != null;



    }
}
