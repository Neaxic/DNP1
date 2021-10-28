using System.Collections.Generic;
using Models;

namespace Data
{
    public interface ITodosData
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int adultID);
        void Update(Adult adultID);
        Adult get(int id);
    }
}