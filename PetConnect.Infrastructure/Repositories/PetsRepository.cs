using CSharpFunctionalExtensions;
using PetConnect.Application.Features.Pets;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Infrastructure.DbContexts;

namespace PetConnect.Infrastructure.Repositories;

/// <summary>
/// Реализация репозитория сущности животного.
/// </summary>
public class PetsRepository(PetConnectWriteDbContext dbContext) : IPetsRepository
{
    /// <summary>
    /// Возвращает сущность с указанным уникальным идентификатором.
    /// </summary>
    public async Task<Result<Pet, Error>> GetById(Guid id, CancellationToken cancellation)
    {
        var result = await dbContext.Pets.FindAsync([id], cancellationToken: cancellation);

        if (result is null)
            return Errors.General.NotFound(id);

        return result;
    }
}
