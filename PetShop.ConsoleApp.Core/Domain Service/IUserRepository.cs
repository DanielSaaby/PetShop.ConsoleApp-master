using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Core.Domain_Service
{
    public interface IUserRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}
