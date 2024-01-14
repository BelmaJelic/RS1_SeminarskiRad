using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.EntityModels;
using WebApplication1.Helper;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProfesorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfesorController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Profesor> Add([FromBody] ProfesorAddVM x)
        {
           //dodati getlog

            var profesor = new Profesor()
            {
                Ime = x.ime,
                Prezime = x.prezime,
                KorisnickoIme = x.korisnickoIme,
            };

            _dbContext.Add(profesor);
            _dbContext.SaveChanges();
            return profesor;
        }

        [HttpGet]
        public List<Profesor> GetAll()
        {
            var data = _dbContext.Profesor
                .OrderBy(s => s.Prezime + " " + s.Ime)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public List<CmbStavke> GetAllCmb()
        {
            var data = _dbContext.Profesor
                .OrderBy(s => s.Prezime + " " + s.Ime)
                .Select(s => new CmbStavke()
                {
                    id = s.Id,
                    opis = s.Prezime + " " + s.Ime,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
