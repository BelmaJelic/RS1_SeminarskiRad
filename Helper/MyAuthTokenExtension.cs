using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Autentifikacija;
using WebApplication1.Data;
using WebApplication1.EntityModels;

namespace WebApplication1.Helper
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }

            public bool isLogiran => korisnickiNalog != null;
            
            public bool isPermisijaProfesor => isLogiran && (korisnickiNalog.profesor != null || korisnickiNalog.isProfesor);
            public bool isPermisijaKorisnik => isLogiran && (korisnickiNalog.korisnik != null || korisnickiNalog.isKorisnik);
            
        }


        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.korisnickiNalog)
                .SingleOrDefault(x => token != null && x.vrijednost == token);

            return korisnickiNalog;
        }


        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    }
}
