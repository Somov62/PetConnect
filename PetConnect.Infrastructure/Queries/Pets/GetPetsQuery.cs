using Microsoft.EntityFrameworkCore;
using PetConnect.Application.Features.Pets.GetPets;
using PetConnect.Infrastructure.DbContexts;

namespace PetConnect.Infrastructure.Queries.Pets;

/// <summary>
/// Запрос на чтение сущностей постранично.
/// </summary>
public class GetPetsQuery(PetConnectReadDbContext dbContext)
{
    public async Task<GetPetsResponse> Execute(GetPetsRequest request, CancellationToken cancellationToken)
    {
        var petsQuery = dbContext.Pets
            .Where(p => string.IsNullOrWhiteSpace(request.Nickname) || p.Nickname.Contains(request.Nickname))
            .Where(p => string.IsNullOrWhiteSpace(request.Breed) || p.Breed.Contains(request.Breed))
            .Where(p => string.IsNullOrWhiteSpace(request.Color) || p.Color.Contains(request.Color))
            .OrderBy(p => p.CreatedDate);

        var totalCount = await petsQuery.CountAsync(cancellationToken);

        var pets = await petsQuery
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(cancellationToken);

        return new(pets, totalCount);
    }
}
