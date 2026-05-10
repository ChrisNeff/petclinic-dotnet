using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Controllers;

[ApiController]
[Route("api/owners")]
[Produces("application/json")]
public class OwnersController : ControllerBase
{
    private readonly IOwnerRepository _owners;

    public OwnersController(IOwnerRepository owners) => _owners = owners;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? lastName)
    {
        var result = string.IsNullOrWhiteSpace(lastName)
            ? await _owners.ListAsync()
            : await _owners.SearchByLastNameAsync(lastName);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var owner = await _owners.GetByIdWithPetsAsync(id);
        return owner == null ? NotFound() : Ok(owner);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Owner owner)
    {
        if (!ModelState.IsValid) return ValidationProblem();

        await _owners.AddAsync(owner);
        return CreatedAtAction(nameof(GetById), new { id = owner.Id }, owner);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Owner owner)
    {
        if (id != owner.Id) return BadRequest();
        if (!ModelState.IsValid) return ValidationProblem();

        var existing = await _owners.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _owners.UpdateAsync(owner);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var owner = await _owners.GetByIdAsync(id);
        if (owner == null) return NotFound();

        await _owners.DeleteAsync(owner);
        return NoContent();
    }
}
