using Microsoft.EntityFrameworkCore;

namespace FineAlcoAPI.Entities
{
    public class BarDbContext : DbContext
    {
        private string _connectionString =
            "Server=.\\SQLExpress;Database=BarDb;Trusted_Connection=Yes;";
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Address> Addresses { get; set; }   
        public DbSet<AlcoDrink> AlcoDrinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bar>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Address>();

            modelBuilder.Entity<AlcoDrink>()
                .Property(d=>d.Name)                
                .IsRequired();

            modelBuilder.Entity<Bar>()
                .HasMany(b => b.AlcoDrinks);
            modelBuilder.Entity<Bar>()
               .HasOne(b => b.Address);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
}
