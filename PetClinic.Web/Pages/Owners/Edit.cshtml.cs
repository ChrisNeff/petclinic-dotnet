using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Owners;

public class EditModel : PageModel
{
    private readonly IOwnerRepository _owners;

    public EditModel(IOwnerRepository owners) => _owners = owners;

    [BindProperty]
    public Owner Owner { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Owner = await _owners.GetByIdAsync(id) ?? null!;
        if (Owner == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _owners.UpdateAsync(Owner);
        return RedirectToPage("./Detail", new { id = Owner.Id });
    }
}
