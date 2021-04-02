using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller")]
  [ApiController]
  // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimals()
    {
      var animals = await _db.Animals.ToListAsync();
      return Ok(animals);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnimal(Animal animal)
    {
      if(ModelState.IsValid)
      {
        await _db.Animals.AddAsync(animal);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetAnimal", new {animal.AnimalId}, animal);
      }

      return new jsonResult("Something went wrong") {StatusCode = 500};
    }

    
  }

}