using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface ITodosData
    {
        IList<Adult> GetAdults();
        Task AddAdult(Adult adult);
        void RemoveAdult(int adultID);
        void Update(Adult adultID);
        Adult get(int id);

        //LOGIN
        IList<User> GetUsers();
    }
}