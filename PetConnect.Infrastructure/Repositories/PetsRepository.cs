using CSharpFunctionalExtensions;
using PetConnect.Domain.Entities;
using PetConnect.Application.Abstractions;
using PetConnect.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace PetConnect.Infrastructure.Repositories;

/// <summary>
/// Реализация репозитория сущности животного.
/// </summary>
public class PetsRepository(PetConnectDbContext dbContext) : IPetsRepository
{
    /// <summary>
    /// Добавляет сущность в базу данных.
    /// </summary>
    public async Task<Result<Guid, Error>> Add(Pet pet, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(pet, cancellationToken);
        var changedRows = await dbContext.SaveChangesAsync(cancellationToken);

        return changedRows == 0 ?
            new Error("record.save", "Животное не сохранилось в бд.") : 
            pet.Id;
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task<Result<Pet, Error>> GetById(Guid id, CancellationToken cancellation)
    {
        var result = await dbContext.Pets.FindAsync(id, cancellation);

        if (result is null)
            return Errors.General.NotFound(id);

        return result;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<Pet>> GetByPage(int page, int size, CancellationToken cancellationToken)
    {
        return await dbContext.Pets
            .AsNoTracking()
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);
    }
}
