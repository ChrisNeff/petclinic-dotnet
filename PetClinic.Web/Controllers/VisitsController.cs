using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Controllers;

[ApiController]
[Produces("application/json")]
public class VisitsController : ControllerBase
{
    private readonly AppDbContext _db;

    public VisitsController(AppDbContext db) => _db = db;

    [HttpGet("api/pets/{petId:int}/visits")]
    public async Task<IActionResult> GetByPet(int petId)
    {
        if (!await _db.Pets.AnyAsync(p => p.Id == petId))
            return NotFound();

        return Ok(await _db.Visits
            .Where(v => v.PetId == petId)
            .OrderByDescending(v => v.VisitDate)
            .ToListAsync());
    }

    [HttpPost("api/pets/{petId:int}/visits")]
    public async Task<IActionResult> Create(int petId, Visit visit)
    {
        if (!await _db.Pets.AnyAsync(p => p.Id == petId))
            return NotFound(new { message = $"Pet {petId} not found." });

        visit.PetId = petId;
        if (!ModelState.IsValid) return ValidationProblem();

        _db.Visits.Add(visit);
        await _db.SaveChangesAsync();
        return Created($"/api/pets/{petId}/visits/{visit.Id}", visit);
    }
}
