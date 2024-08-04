namespace PetConnect.Application.Dtos;

/// <summary>
/// Класс фотки для клиента.
/// </summary>
public record PhotoDto
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Путь к файлу.
    /// </summary>
    public string Path { get; init; } = string.Empty;

    /// <summary>
    /// Является ли фотка главной.
    /// </summary>
    public bool IsMain { get; init; }

    /// <summary>
    /// Уникальный идетификатор владельца.
    /// </summary>
    public Guid OwnerId { get; init; }
}