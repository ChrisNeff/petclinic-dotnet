using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Controllers;

[ApiController]
[Produces("application/json")]
public class PetsController : ControllerBase
{
    private readonly AppDbContext _db;

    public PetsController(AppDbContext db) => _db = db;

    [HttpGet("api/pets/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pet = await _db.Pets
            .Include(p => p.PetType)
            .Include(p => p.Visits)
            .FirstOrDefaultAsync(p => p.Id == id);

        return pet == null ? NotFound() : Ok(pet);
    }

    [HttpPost("api/owners/{ownerId:int}/pets")]
    public async Task<IActionResult> Create(int ownerId, Pet pet)
    {
        if (!await _db.Owners.AnyAsync(o => o.Id == ownerId))
            return NotFound(new { message = $"Owner {ownerId} not found." });

        pet.OwnerId = ownerId;
        if (!ModelState.IsValid) return ValidationProblem();

        _db.Pets.Add(pet);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
    }

    [HttpPut("api/pets/{id:int}")]
    public async Task<IActionResult> Update(int id, Pet pet)
    {
        if (id != pet.Id) return BadRequest();
        if (!ModelState.IsValid) return ValidationProblem();

        _db.Entry(pet).State = EntityState.Modified;

        try { await _db.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _db.Pets.AnyAsync(p => p.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("api/pets/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await _db.Pets.FindAsync(id);
        if (pet == null) return NotFound();

        _db.Pets.Remove(pet);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
