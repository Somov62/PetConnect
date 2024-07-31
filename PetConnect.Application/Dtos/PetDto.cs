namespace PetConnect.Application.Dtos;

/// <summary>
/// 
/// </summary>
public class PetDto
{
    public Guid Id { get; init; }
    public string Nickname { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Breed { get; init; } = string.Empty;
    public string Color { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Street { get; init; } = string.Empty;
    public string Building { get; init; } = string.Empty;
    public string Postcode { get; init; } = string.Empty;
    public string ContactPhoneNumber { get; init; } = string.Empty;
    public DateTimeOffset CreatedDate { get; init; }
    public List<PhotoDto> Photos { get; init; } = [];
}