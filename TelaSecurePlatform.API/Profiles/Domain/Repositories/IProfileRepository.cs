using TelaSecurePlatform.API.Profiles.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Profiles.Domain.Model.ValueObjects;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Profiles.Domain.Repositories;

/// <summary>
/// Profile repository interface 
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    /// <summary>
    /// Find a profile by email 
    /// </summary>
    /// <param name="email">
    /// The <see cref="EmailAddress"/> email address to search for
    /// </param>
    /// <returns>
    /// The <see cref="Profile"/> if found, otherwise null
    /// </returns>
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}