using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Interfaces;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _db;

    public Repository(AppDbContext db) => _db = db;

    public async Task<T?> GetByIdAsync(int id) =>
        await _db.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> ListAsync() =>
        await _db.Set<T>().ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        _db.Set<T>().Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync();
    }
}
