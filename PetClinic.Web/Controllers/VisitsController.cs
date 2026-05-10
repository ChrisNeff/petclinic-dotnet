using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Controllers;

[ApiController]
[Produces("application/json")]
public class VisitsController : ControllerBase
{
    private readonly IRepository<Visit> _visits;
    private readonly IRepository<Pet> _pets;

    public VisitsController(IRepository<Visit> visits, IRepository<Pet> pets)
    {
        _visits = visits;
        _pets = pets;
    }

    [HttpGet("api/pets/{petId:int}/visits")]
    public async Task<IActionResult> GetByPet(int petId)
    {
        var pet = await _pets.GetByIdAsync(petId);
        if (pet == null) return NotFound();

        var visits = await _visits.ListAsync();
        return Ok(visits.Where(v => v.PetId == petId).OrderByDescending(v => v.VisitDate));
    }

    [HttpPost("api/pets/{petId:int}/visits")]
    public async Task<IActionResult> Create(int petId, Visit visit)
    {
        var pet = await _pets.GetByIdAsync(petId);
        if (pet == null) return NotFound(new { message = $"Pet {petId} not found." });

        visit.PetId = petId;
        if (!ModelState.IsValid) return ValidationProblem();

        await _visits.AddAsync(visit);
        return Created($"/api/pets/{petId}/visits/{visit.Id}", visit);
    }
}
