using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using Entity = PetConnect.Domain.Common.Entity;

namespace PetConnect.Domain.Entities;

/// <summary>
/// Модель фотографии.
/// </summary>
public class Photo : Entity
{
    private Photo() { }

    private Photo(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }

    /// <summary>
    /// Путь к файлу.
    /// </summary>
    public string Path { get; private set; } = null!;

    /// <summary>
    /// Главное фото.
    /// </summary>
    public bool IsMain { get; set; }

    public static Result<Photo, Error> Create(string path, bool isMain)
    {
        return new Photo(path, isMain);
    }
}