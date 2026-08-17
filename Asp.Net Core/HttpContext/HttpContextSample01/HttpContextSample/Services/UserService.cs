namespace HttpContextSample.Services
{
    public class UserService(IHttpContextAccessor accessor)
    {
        public string? GetCurrentUser() => accessor.HttpContext?.User.Identity?.Name;
    }
}
