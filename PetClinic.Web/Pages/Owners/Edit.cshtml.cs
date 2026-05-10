using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Owners;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;

    public EditModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Owner Owner { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Owner = await _db.Owners.FindAsync(id) ?? null!;
        if (Owner == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _db.Entry(Owner).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return RedirectToPage("./Detail", new { id = Owner.Id });
    }
}
