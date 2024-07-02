namespace PetConnect.Domain;

public class MainPhoto
{
    public MainPhoto(string photoPath)
    {
        PhotoPath = photoPath;
    }

    public string PhotoPath { get; private set; }
}