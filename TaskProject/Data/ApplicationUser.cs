using Microsoft.AspNetCore.Identity;

namespace TaskProject.Data;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? FacebookProfileLink { get; set; }
    public string? InstagramProfileLink { get; set; }
    public string? GoogleProfileLink { get; set; }
    public string? LinkedInProfileLink { get; set; }
    
    public void UpdateFacebookProfileLink(string? facebookProfileLink)
    {
        FacebookProfileLink = facebookProfileLink;
    }
    
    public void UpdateInstagramProfileLink(string? instagramProfileLink)
    {
        InstagramProfileLink = instagramProfileLink;
    }
    
    public void UpdateGoogleProfileLink(string? googleProfileLink)
    {
        GoogleProfileLink = googleProfileLink;
    }
    
    public void UpdateLinkedInProfileLink(string? linkedInProfileLink)
    {
        LinkedInProfileLink = linkedInProfileLink;
    }
}


