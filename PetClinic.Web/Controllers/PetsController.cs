using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Controllers;

[ApiController]
[Produces("application/json")]
public class PetsController : ControllerBase
{
    private readonly IRepository<Pet> _pets;
    private readonly IOwnerRepository _owners;

    public PetsController(IRepository<Pet> pets, IOwnerRepository owners)
    {
        _pets = pets;
        _owners = owners;
    }

    [HttpGet("api/pets/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pet = await _pets.GetByIdAsync(id);
        return pet == null ? NotFound() : Ok(pet);
    }

    [HttpPost("api/owners/{ownerId:int}/pets")]
    public async Task<IActionResult> Create(int ownerId, Pet pet)
    {
        var owner = await _owners.GetByIdAsync(ownerId);
        if (owner == null) return NotFound(new { message = $"Owner {ownerId} not found." });

        pet.OwnerId = ownerId;
        if (!ModelState.IsValid) return ValidationProblem();

        await _pets.AddAsync(pet);
        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
    }

    [HttpPut("api/pets/{id:int}")]
    public async Task<IActionResult> Update(int id, Pet pet)
    {
        if (id != pet.Id) return BadRequest();
        if (!ModelState.IsValid) return ValidationProblem();

        var existing = await _pets.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _pets.UpdateAsync(pet);
        return NoContent();
    }

    [HttpDelete("api/pets/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await _pets.GetByIdAsync(id);
        if (pet == null) return NotFound();

        await _pets.DeleteAsync(pet);
        return NoContent();
    }
}
