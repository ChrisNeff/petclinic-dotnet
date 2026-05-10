using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Owners;

public class DetailModel : PageModel
{
    private readonly IOwnerRepository _owners;

    public DetailModel(IOwnerRepository owners) => _owners = owners;

    public Owner? Owner { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Owner = await _owners.GetByIdWithPetsAsync(id);
        if (Owner == null) return NotFound();
        return Page();
    }
}
