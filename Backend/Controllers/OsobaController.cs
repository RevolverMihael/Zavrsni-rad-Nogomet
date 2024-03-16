using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OsobaController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public OsobaController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Osobe.ToList());

        }

        [HttpPost]
        public IActionResult Post(Osoba osoba)
        {
            _context.Osobe.Add(osoba);
            _context.SaveChanges();
            return new JsonResult(osoba);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Osoba osoba)
        {
            var osobaIzBaze = _context.Osobe.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            osobaIzBaze.Ime = osoba.Ime;
            osobaIzBaze.Prezime = osoba.Prezime;
            osobaIzBaze.Email = osoba.Email;
            osobaIzBaze.Oib = osoba.Oib;

            _context.Osobe.Update(osobaIzBaze);
            _context.SaveChanges();

            return new JsonResult(osobaIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var osobaIzBaze = _context.Osobe.Find(sifra);
            _context.Osobe.Remove(osobaIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }

    }
}
