namespace OrderManagementSystem.Api.Authentication
{
    public interface IJwtAuthentication
    {
        public string Authenticate(string userId, DateTime? validTill = null);
    }
}
