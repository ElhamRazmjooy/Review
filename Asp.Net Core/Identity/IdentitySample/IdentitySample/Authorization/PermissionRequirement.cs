using Microsoft.AspNetCore.Authorization;

namespace IdentitySample.Authorization
{
    public class PermissionRequirement(string permission) : IAuthorizationRequirement
    {
        public string Permission { get; } = permission;

    }
}
