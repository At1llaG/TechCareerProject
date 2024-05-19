using Microsoft.EntityFrameworkCore;
using TechCareer.Website.Models;

public class TechCareerDbContext : DbContext
{
    public TechCareerDbContext(DbContextOptions<TechCareerDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Expense> Expenses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}
