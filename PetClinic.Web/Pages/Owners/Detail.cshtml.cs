using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Owners;

public class DetailModel : PageModel
{
    private readonly AppDbContext _db;

    public DetailModel(AppDbContext db) => _db = db;

    public Owner? Owner { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Owner = await _db.Owners
            .Include(o => o.Pets).ThenInclude(p => p.PetType)
            .Include(o => o.Pets).ThenInclude(p => p.Visits)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (Owner == null) return NotFound();
        return Page();
    }
}
