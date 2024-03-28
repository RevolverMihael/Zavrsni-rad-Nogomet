using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TrenerController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public TrenerController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {           
                return new JsonResult(_context.Treneri.ToList());
            
        }

        [HttpPost]
        public IActionResult Post(Trener trener)
        {
            _context.Treneri.Add(trener);
            _context.SaveChanges();
            return new JsonResult(trener);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return new JsonResult(_context.Treneri.Find(sifra));
        }



        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Trener trener)
        {
            var trenerIzBaze = _context.Treneri.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            trenerIzBaze.Ime = trener.Ime;
            trenerIzBaze.Prezime= trener.Prezime;
            trenerIzBaze.Datum_Rodenja = trener.Datum_Rodenja;
            trenerIzBaze.Broj_Postignuca = trener.Broj_Postignuca;
            

            _context.Treneri.Update(trenerIzBaze);
            _context.SaveChanges();

            return new JsonResult(trenerIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var trenerIzBaze = _context.Treneri.Find(sifra);
            _context.Treneri.Remove(trenerIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
