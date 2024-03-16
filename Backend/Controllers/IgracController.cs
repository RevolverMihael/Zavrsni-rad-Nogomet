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

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Igrac smjer)
        {
            var smjerIzBaze = _context.Igraci.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            smjerIzBaze.Ime = smjer.Ime;
            smjerIzBaze.Prezime= smjer.Prezime;
            smjerIzBaze.Pozicija= smjer.Pozicija;
            smjerIzBaze.BrojGolova=smjer.BrojGolova;

            _context.Igraci.Update(smjerIzBaze);
            _context.SaveChanges();

            return new JsonResult(smjerIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var smjerIzBaze = _context.Igraci.Find(sifra);
            _context.Igraci.Remove(smjerIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
