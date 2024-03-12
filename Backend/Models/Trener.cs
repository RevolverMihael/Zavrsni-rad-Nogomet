namespace Backend.Models
{
    public class Trener:Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public int? BrojPostignuca { get; set; }
    }
}
