using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IgracController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public IgracController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Igraci.ToList());

        }

        [HttpPost]
        public IActionResult Post(Igrac igrac)
        {
            _context.Igraci.Add(igrac);
            _context.SaveChanges();
            return new JsonResult(igrac);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra) 
        {
            return new JsonResult(_context.Igraci.Find(sifra));
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Igrac igrac)
        {
            var igracIzBaze = _context.Igraci.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            igracIzBaze.Ime = igrac.Ime;
            igracIzBaze.Prezime = igrac.Prezime;
            igracIzBaze.Pozicija = igrac.Pozicija;
            igracIzBaze.BrojGolova = igrac.BrojGolova;

            _context.Igraci.Update(igracIzBaze);
            _context.SaveChanges();

            return new JsonResult(igracIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var igracIzBaze = _context.Igraci.Find(sifra);
            _context.Igraci.Remove(igracIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }

    }
}
