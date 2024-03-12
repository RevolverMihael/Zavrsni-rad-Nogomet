using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Igrac:Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Pozicija { get; set; }
        [Column("broj_golova")]
        public int? BrojGolova { get; set; }
    }
}
