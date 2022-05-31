using Epam.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.DAL.Interfaces
{
    public interface IUsersDAO
    {
        User AddUser(string name, DateTime dateOfBirth);

        void RemoveUser(Guid id);

        void EditUser(Guid id, string newName, DateTime newDateOfBirth);

        User GetUser(Guid id);

        IEnumerable<User> GetUsers(bool orderedById);
    }
}