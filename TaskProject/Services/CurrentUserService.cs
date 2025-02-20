using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace TaskProject.Services;

public interface ICurrentUserService
{
    Task<Guid> GetCurrentUserIdAsync();
}

public class CurrentUserService(AuthenticationStateProvider authenticationStateProvider) : ICurrentUserService
{
    public async Task<Guid> GetCurrentUserIdAsync()
    {
        AuthenticationState authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        ClaimsPrincipal user = authState.User;

        if (user.Identity is not { IsAuthenticated: true })
        {
            return Guid.Empty;
        }

        string? userIdValue = user.FindFirstValue(ClaimTypes.NameIdentifier);
        
        return Guid.TryParse(userIdValue, out Guid userId) 
            ? userId 
            : Guid.Empty;
    }
}