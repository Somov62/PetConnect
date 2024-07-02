namespace PetConnect.Domain;

public class Photo
{
    public Photo(Guid id, string path)
    {
        Id = id;
        Path = path;
    }

    public Guid Id { get; private set; }
    public string Path { get; private set; }
}