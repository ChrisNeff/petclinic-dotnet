using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Owners;

public class CreateModel : PageModel
{
    private readonly IOwnerRepository _owners;

    public CreateModel(IOwnerRepository owners) => _owners = owners;

    [BindProperty]
    public Owner Owner { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _owners.AddAsync(Owner);
        return RedirectToPage("./Detail", new { id = Owner.Id });
    }
}
