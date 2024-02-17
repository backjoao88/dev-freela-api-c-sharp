namespace FreelaDev.MsProjects.Application.ViewModels;

/// <summary>
/// Represent a return response of the signin request.
/// </summary>
public class SignInRequest
{
    public SignInRequest(Guid userId, string token)
    {
        UserId = userId;
        Token = token;
    }
    public Guid UserId { get; set; }
    public string Token { get; set; }
}