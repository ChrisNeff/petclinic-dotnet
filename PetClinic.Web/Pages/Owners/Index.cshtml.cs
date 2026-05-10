using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Owners;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db) => _db = db;

    public IReadOnlyList<Owner> Owners { get; set; } = [];
    [BindProperty(SupportsGet = true)]
    public string? LastName { get; set; }

    public async Task OnGetAsync()
    {
        var query = _db.Owners.Include(o => o.Pets).AsQueryable();

        if (!string.IsNullOrWhiteSpace(LastName))
            query = query.Where(o => o.LastName.Contains(LastName));

        Owners = await query.OrderBy(o => o.LastName).ToListAsync();
    }
}
