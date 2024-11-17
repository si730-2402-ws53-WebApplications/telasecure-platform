using TelaSecurePlatform.API.IAM.Domain.Model.Aggregates;
using TelaSecurePlatform.API.IAM.Domain.Model.Queries;
using TelaSecurePlatform.API.IAM.Domain.Repositories;
using TelaSecurePlatform.API.IAM.Domain.Services;

namespace TelaSecurePlatform.API.IAM.Application.Internal.QueryServices;

/// <summary>
/// User query service 
/// </summary>
/// <remarks>
/// This class is responsible for handling user queries. 
/// </remarks>
/// <param name="userRepository">
/// The <see cref="IUserRepository"/> user repository
/// </param>
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    // inheritDoc
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }

    // inheritDoc
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    // inheritDoc
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}