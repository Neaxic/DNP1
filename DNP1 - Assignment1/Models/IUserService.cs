namespace DNP1___Assignment1.Models
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}