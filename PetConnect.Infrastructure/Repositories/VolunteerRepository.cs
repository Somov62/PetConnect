﻿using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetConnect.Application.Features.Volunteers;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Infrastructure.DbContexts;

namespace PetConnect.Infrastructure.Repositories;

/// <summary>
/// Реализация репозитория сущности волонтера.
/// </summary>
public class VolunteerRepository(PetConnectWriteDbContext dbContext) : IVolunteersRepository
{
    /// <inheritdoc/>
    public async Task Add(Volunteer volunteer, CancellationToken cancellationToken)
    {
        await dbContext.Volunteers.AddAsync(volunteer, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Result<Volunteer, Error>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await dbContext.Volunteers
            .Include(v => v.Pets)
            .Include(v => v.Photos)
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken: cancellationToken);


        if (result is null)
            return Errors.General.NotFound(id);

        return result;
    }

    /// <inheritdoc/>
    public async Task<Result<int, Error>> Save(CancellationToken cancellationToken)
    {
        var changedRows = await dbContext.SaveChangesAsync(cancellationToken);

        return changedRows == 0 ?
            Errors.Database.SaveFailure("Волонтер") :
            changedRows;
    }
}
