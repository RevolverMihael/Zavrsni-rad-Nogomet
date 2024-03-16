using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) {
        
        }

        public DbSet<Igrac> Igraci { get; set; }
        public DbSet<Momcad> Momcadi { get; set; }
        public DbSet<Trener> Treneri { get; set; }


    }
}
