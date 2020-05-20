using Microsoft.EntityFrameworkCore;

namespace Zadanie
{
    public class FootballContext : DbContext
    
    {
        public DbSet<Teams> Teamses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=FootballDb;User Id=sa;Password=Sebastian1998;");
            
        }
    }
}