using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.EntityModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradController : Controller
    {
        private ApplicationDbContext _dbContext;
        public GradController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<Grad> GetAll()
        {
            return _dbContext.Grad.ToList();
        }
        [HttpPost]
        public ActionResult Add(string naziv)
        {
            Grad novigrad = new Grad() { Naziv = naziv };
            _dbContext.Grad.Add(novigrad);
            _dbContext.SaveChanges();
            return Ok(novigrad.Id);
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Grad grad = _dbContext.Grad.Find(id);

            if (grad == null)//|| id == 1
                return BadRequest("ne postoji taj ID");

            _dbContext.Remove(grad);

            _dbContext.SaveChanges();
            return Ok(grad);
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
