namespace PetConnect.Domain;

/// <summary>
/// Модель объявления о животном.
/// </summary>
public class Post
{
    public Post(
        string name,
        string breed,
        Weight weight,
        int height,
        bool vaccine,
        DateOnly birthDate,
        MainPhoto photo,
        string description,
        string address)
    {
        Name = name;
        Breed = breed;
        Weight = weight;
        Height = height;
        Vaccine = vaccine;
        BirthDate = birthDate;
        MainPhoto = photo;
        Description = description;
        Address = address;
    }

    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Порода.
    /// </summary>
    public string Breed { get; private set; } = string.Empty;

    /// <summary>
    /// Вес.
    /// </summary>
    public Weight Weight { get; private set; } = default!;

    /// <summary>
    /// Высота.
    /// </summary>
    public int Height { get; private set; }

    /// <summary>
    /// Наличие вакцин
    /// </summary>
    public bool Vaccine { get; private set; }

    /// <summary>
    /// День рождения.
    /// </summary>
    public DateOnly BirthDate { get; private set; }

    /// <summary>
    /// Фото.
    /// </summary>
    public MainPhoto MainPhoto { get; private set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Адрес.
    /// </summary>
    public string Address { get; private set; } = string.Empty;


    public List<Photo> Photos { get; private set; } = [];
}
