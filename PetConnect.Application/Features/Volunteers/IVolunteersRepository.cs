using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Features.Volunteers;

/// <summary>
/// Репозиторий для взаимодействия сервисов с сущностями волонтера.
/// </summary>
public interface IVolunteersRepository
{
    /// <summary>
    /// Добавляет информацию о волонтере в систему.
    /// </summary>
    Task Add(Volunteer volunteer, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает сущность с указанным уникальным идентификатором.
    /// </summary>
    Task<Result<Volunteer, Error>> GetById(Guid id, CancellationToken cancellation);
        
    /// <summary>
    /// Сохраняет изменения.
    /// </summary>
    Task<Result<int, Error>> Save(CancellationToken cancellation);
}