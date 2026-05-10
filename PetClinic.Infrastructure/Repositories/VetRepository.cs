using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Infrastructure.Repositories;

public class VetRepository : Repository<Vet>, IVetRepository
{
    public VetRepository(AppDbContext db) : base(db) { }

    public async Task<IReadOnlyList<Vet>> ListWithSpecialtiesAsync() =>
        await _db.Vets
            .Include(v => v.VetSpecialties)
                .ThenInclude(vs => vs.Specialty)
            .OrderBy(v => v.LastName)
            .ToListAsync();
}
