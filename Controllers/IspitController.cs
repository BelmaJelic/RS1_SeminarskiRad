using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.EntityModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IspitController : Controller
    {

        private ApplicationDbContext _dbContext;

        public IspitController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Ispit>> GetByDatum(DateTime? periodOd, DateTime? periodDo)
        {
            List<Ispit> podaci = _dbContext.Ispit
                .Where(x => periodOd == null || x.DatumIspita >= periodOd)
                .Where(x => periodDo == null || x.DatumIspita <= periodDo)
                .ToList();

            return podaci;
        }
        [HttpPost]
        public ActionResult AddUrlParam(DateTime datumIspita, int kursId, string naziv)
        {

          //treba dodati getLogInfo

            Ispit ispit = new Ispit
            {
                DatumIspita = datumIspita,
                Naziv = naziv,
                KursId = kursId
            };
            _dbContext.Add(ispit);
            _dbContext.SaveChanges();//izvršava potreban SQL

            return Ok();
        }
    }
}
