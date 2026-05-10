using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Controllers;

[ApiController]
[Route("api/vets")]
[Produces("application/json")]
public class VetsController : ControllerBase
{
    private readonly IVetRepository _vets;

    public VetsController(IVetRepository vets) => _vets = vets;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _vets.ListWithSpecialtiesAsync());
}
