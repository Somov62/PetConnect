namespace PetConnect.Application.Dtos;

/// <summary>
/// 
/// </summary>
public record PhotoDto
{
    public Guid Id { get; init; }
    public string Path { get; init; } = string.Empty;
    public bool IsMain { get; init; }
    public Guid OwnerId { get; init; }
}