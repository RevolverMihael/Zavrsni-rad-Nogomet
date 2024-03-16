namespace Backend.Models
{
    public class Trener:Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime? Datum_Rodenja { get; set; }
        public int? Broj_Postignuca { get; set; }
    }
}
