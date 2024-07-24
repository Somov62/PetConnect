namespace PetConnect.Domain.Entities;

public class Photo
{
    /// <summary>
    /// Пустой конструктор для DbContext.
    /// </summary>
    private Photo() { }


    /// <summary>
    /// Основной конструктор.
    /// </summary>
    public Photo(Guid id, string path)
    {
        Id = id;
        Path = path;
    }

    public Guid Id { get; private set; }
    public string Path { get; private set; } = null!;

    public bool IsMain { get; set; }
}