namespace TaskProject.Services;

public interface ISocialNetworksService
{
    public Task<Uri> GetUserSocialNetworkProfileUrlForFacebookAsync();
    public Task<Uri> GetUserSocialNetworkProfileUrlForInstagramAsync(); 
    public Task<Uri> GetUserSocialNetworkProfileUrlForLinkedInAsync(); 
    public Task<Uri> GetUserSocialNetworkProfileUrlForGoogleAsync(); 
}

public class SocialNetworksService : ISocialNetworksService
{
    public Task<Uri> GetUserSocialNetworkProfileUrlForFacebookAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Uri> GetUserSocialNetworkProfileUrlForInstagramAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Uri> GetUserSocialNetworkProfileUrlForLinkedInAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Uri> GetUserSocialNetworkProfileUrlForGoogleAsync()
    {
        throw new NotImplementedException();
    }
}
