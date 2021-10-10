using System.Collections.Generic;
using DNP1___Assignment1.Models;
using Models;

namespace DNP1___Assignment1.Data
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