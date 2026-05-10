using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Infrastructure.Repositories;

public class OwnerRepository : Repository<Owner>, IOwnerRepository
{
    public OwnerRepository(AppDbContext db) : base(db) { }

    public async Task<IReadOnlyList<Owner>> SearchByLastNameAsync(string lastName) =>
        await _db.Owners
            .Where(o => o.LastName.Contains(lastName))
            .OrderBy(o => o.LastName)
            .ToListAsync();

    public async Task<Owner?> GetByIdWithPetsAsync(int id) =>
        await _db.Owners
            .Include(o => o.Pets)
                .ThenInclude(p => p.PetType)
            .Include(o => o.Pets)
                .ThenInclude(p => p.Visits)
            .FirstOrDefaultAsync(o => o.Id == id);
}
