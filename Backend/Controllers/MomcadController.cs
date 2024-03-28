using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MomcadController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public MomcadController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {           
                return new JsonResult(_context.Momcadi.ToList());
            
        }

        [HttpPost]
        public IActionResult Post(Momcad momcad)
        {
            _context.Momcadi.Add(momcad);
            _context.SaveChanges();
            return new JsonResult(momcad);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return new JsonResult(_context.Momcadi.Find(sifra));
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Momcad momcad)
        {
            var momcadIzBaze = _context.Momcadi.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            momcadIzBaze.Naziv_Kluba = momcad.Naziv_Kluba;
            momcadIzBaze.Liga= momcad.Liga;
            

            _context.Momcadi.Update(momcadIzBaze);
            _context.SaveChanges();

            return new JsonResult(momcadIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var momcadIzBaze = _context.Momcadi.Find(sifra);
            _context.Momcadi.Remove(momcadIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
