namespace PetConnect.Application.Dtos;

/// <summary>
/// Класс животного для клиента.
/// </summary>
public class PetDto
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Кличка.
    /// </summary>
    public string Nickname { get; init; } = string.Empty;

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Порода.
    /// </summary>
    public string Breed { get; init; } = string.Empty;

    /// <summary>
    /// Окрас.
    /// </summary>
    public string Color { get; init; } = string.Empty;

    /// <summary>
    /// Расположение - город.
    /// </summary>
    public string City { get; init; } = string.Empty;

    /// <summary>
    /// Расположение - улица.
    /// </summary>
    public string Street { get; init; } = string.Empty;

    /// <summary>
    /// Расположение - дом/строение.
    /// </summary>
    public string Building { get; init; } = string.Empty;

    /// <summary>
    /// Расположение - почтовый индекс.
    /// </summary>
    public string Postcode { get; init; } = string.Empty;

    /// <summary>
    /// Номер телефона человека, у которого на данный момент находится животное, для связи.
    /// </summary>
    public string ContactPhoneNumber { get; init; } = string.Empty;

    /// <summary>
    /// Дата регистрации животного.
    /// </summary>
    public DateTimeOffset CreatedDate { get; init; }

    /// <summary>
    /// Фотки.
    /// </summary>
    public List<PhotoDto> Photos { get; init; } = [];
}