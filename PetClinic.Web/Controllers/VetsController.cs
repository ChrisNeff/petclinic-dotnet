using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Controllers;

[ApiController]
[Route("api/vets")]
[Produces("application/json")]
public class VetsController : ControllerBase
{
    private readonly AppDbContext _db;

    public VetsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.Vets
            .Include(v => v.VetSpecialties)
                .ThenInclude(vs => vs.Specialty)
            .OrderBy(v => v.LastName)
            .ToListAsync());
}
