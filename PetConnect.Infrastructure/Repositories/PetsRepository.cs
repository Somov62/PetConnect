using CSharpFunctionalExtensions;
using PetConnect.Domain.Entities;
using PetConnect.Application.Abstractions;
using PetConnect.Domain.Common;

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
}
