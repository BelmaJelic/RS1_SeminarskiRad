using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.EntityModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KursController : Controller
    {

        private ApplicationDbContext _dbContext;

        public KursController(ApplicationDbContext dbContext)
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
        public ActionResult AddUrlParam(DateTime datumKursa, string naziv)
        {

            //treba dodati getLogInfo

            Kurs kurs = new Kurs()
            {
                Datum = datumKursa,
                Naziv = naziv
                
            };
            _dbContext.Add(kurs);
            _dbContext.SaveChanges();//izvršava potreban SQL

            return Ok();
        }
    }
}
