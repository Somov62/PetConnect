using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Features.Pets;

/// <summary>
/// Репозиторий для взаимодействия сервисов с сущностями животного.
/// </summary>
public interface IPetsRepository
{
    /// <summary>
    /// Возвращает сущность с указанным уникальным идентификатором.
    /// </summary>
    Task<Result<Pet, Error>> GetById(Guid id, CancellationToken cancellation);
}
