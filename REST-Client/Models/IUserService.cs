namespace Models
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}