using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PersonDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
}