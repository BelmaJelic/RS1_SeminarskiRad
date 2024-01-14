using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.EntityModels;
using WebApplication1.Helper;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            return Ok(_dbContext.Korisnik.Include(s => s.Grad.Naziv).FirstOrDefault(s => s.Id == id)); ;
        }


        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] KorisnikUpdateVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            Korisnik korisnik;

            if (id == 0)
            {
                korisnik = new Korisnik
                {
                    Slika = Config.SlikeURL + "empty.png",
                    
                };
                _dbContext.Add(korisnik);
            }
            else
            {
                korisnik = _dbContext.Korisnik.Include(s => s.Grad.Naziv).FirstOrDefault(s => s.Id == id);
                if (korisnik == null)
                    return BadRequest("pogresan ID");
            }

            korisnik.KorisnickoIme = x.ime;
            korisnik.Adresa = x.adresa;
            korisnik.Grad.Naziv = x.grad;
           


            _dbContext.SaveChanges();
            return Get(korisnik.Id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            Korisnik student = _dbContext.Korisnik.Find(id);

            if (student == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(student);

            _dbContext.SaveChanges();
            return Ok(student);
        }

        [HttpGet]
        public ActionResult<List<Korisnik>> GetAll(string ime_prezime)
        {
            var data = _dbContext.Korisnik
                .Include(s => s.Grad.Naziv)
                .Where(x => ime_prezime == null)
                .OrderByDescending(s => s.Id)
                .AsQueryable();
            return data.Take(100).ToList();
        }

    }
}
