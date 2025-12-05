using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //Behöver bara pilla med dessa om man har många till många relationer. Annars om man använder listor mellan tabeller så får man konstiga namn.
    }
}
