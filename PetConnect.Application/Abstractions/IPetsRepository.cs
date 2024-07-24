using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Abstractions;

/// <summary>
/// Репозиторий для взаимодействия сервисов с сущностями животного.
/// </summary>
public interface IPetsRepository
{
    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    Task<Result<Guid, Error>> Add(Pet pet, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает сущности постранично.
    /// </summary>
    Task<IReadOnlyList<Pet>> GetByPage(int page, int size, CancellationToken cancellationToken);
}
