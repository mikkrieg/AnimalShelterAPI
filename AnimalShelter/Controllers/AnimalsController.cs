using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>>Get(string name, string gender, string species, string personality )
    {
      var query = _db.Animals.AsQueryable();
      if(name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if(gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      if(species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }
      if(personality != null)
      {
        query = query.Where(entry => entry.Personality == personality);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);

      if(animal == null)
      {
        return NotFound();
      }

      return Ok(animal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnimal(Animal animal)
    {
      
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId}, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, Animal animal)
    {
      if(id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}