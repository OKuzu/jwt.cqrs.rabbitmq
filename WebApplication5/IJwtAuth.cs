namespace MemberJWTDemo
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}