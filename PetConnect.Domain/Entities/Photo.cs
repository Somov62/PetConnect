namespace PetConnect.Domain.Entities;

/// <summary>
/// 
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
    /// 
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Path { get; private set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public bool IsMain { get; set; }
}