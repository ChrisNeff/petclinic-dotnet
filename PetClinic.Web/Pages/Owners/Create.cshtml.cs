using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Owners;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;

    public CreateModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Owner Owner { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _db.Owners.Add(Owner);
        await _db.SaveChangesAsync();
        return RedirectToPage("./Detail", new { id = Owner.Id });
    }
}
