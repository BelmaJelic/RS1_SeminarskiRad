using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.EntityModels;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{ 


    [ApiController]
    [Route("[Controller]/[action]")]
    public class KategorijaKursaController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public KategorijaKursaController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;

        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = _dbcontext.KategorijaKursa.OrderBy(x => x.Naziv)
                .Select(x => new NovaKategorija()
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                   

                }).Take(100);
            return Ok(podaci.ToList());

        }
        [HttpPost]
        public ActionResult Dodaj(string naziv)
        {
            KategorijaKursa novakateg = new KategorijaKursa() { Naziv = naziv,  };
            _dbcontext.KategorijaKursa.Add(novakateg);
            _dbcontext.SaveChanges();
            return Ok(novakateg);
        }
        [HttpDelete]
        public ActionResult DeleteKategorija([FromQuery] int id)
        {
            var kategorija = _dbcontext.KategorijaKursa.Where(x => x.Id == id).FirstOrDefault();
            if (kategorija == null)
            {
                return BadRequest("this id doesnt exist");
            }
            _dbcontext.Remove(kategorija);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
