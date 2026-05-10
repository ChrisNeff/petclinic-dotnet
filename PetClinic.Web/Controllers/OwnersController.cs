using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Controllers;

[ApiController]
[Route("api/owners")]
[Produces("application/json")]
public class OwnersController : ControllerBase
{
    private readonly AppDbContext _db;

    public OwnersController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? lastName)
    {
        var query = _db.Owners.Include(o => o.Pets).ThenInclude(p => p.PetType).AsQueryable();

        if (!string.IsNullOrWhiteSpace(lastName))
            query = query.Where(o => o.LastName.Contains(lastName));

        return Ok(await query.OrderBy(o => o.LastName).ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var owner = await _db.Owners
            .Include(o => o.Pets).ThenInclude(p => p.PetType)
            .Include(o => o.Pets).ThenInclude(p => p.Visits)
            .FirstOrDefaultAsync(o => o.Id == id);

        return owner == null ? NotFound() : Ok(owner);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Owner owner)
    {
        if (!ModelState.IsValid) return ValidationProblem();

        _db.Owners.Add(owner);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = owner.Id }, owner);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Owner owner)
    {
        if (id != owner.Id) return BadRequest();
        if (!ModelState.IsValid) return ValidationProblem();

        _db.Entry(owner).State = EntityState.Modified;

        try { await _db.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _db.Owners.AnyAsync(o => o.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var owner = await _db.Owners.FindAsync(id);
        if (owner == null) return NotFound();

        _db.Owners.Remove(owner);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
