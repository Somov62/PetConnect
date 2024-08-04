namespace PetConnect.Domain.Entities;

/// <summary>
/// Модель фотографии.
/// </summary>
public class Photo
{
    private Photo() { }

    public Photo(Guid id, string path, bool isMain)
    {
        Id = id;
        Path = path;
        IsMain = isMain;
    }

    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Путь к файлу.
    /// </summary>
    public string Path { get; private set; } = null!;

    /// <summary>
    /// Главное фото.
    /// </summary>
    public bool IsMain { get; set; }
}