using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : IdentityDbContext
  {
    public virtual DbSet<Animal> Animals { get; set; }

    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
      : base(options)
    {
      
    }
  }
}