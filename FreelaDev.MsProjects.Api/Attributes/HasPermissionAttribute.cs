using FreelaDev.MsProjects.Core.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace FreelaDev.MsProjects.Api.Attributes;

/// <summary>
/// Represents a permission attribute.
/// </summary>
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(params ERole[] roles)
    {
        var loweredRoles = roles.Select(o => o.ToString().ToLower());
        Roles = string.Join(", ", loweredRoles);
    }
}