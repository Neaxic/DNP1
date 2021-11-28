using System.Threading.Tasks;

namespace Models
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}