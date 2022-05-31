using Epam.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.BLL.Interfaces
{
    public interface IUsersLogic
    {
        User AddUser(string name, DateTime dateOfBirth);

        void RemoveUser(Guid id);

        void EditUser(Guid id, string newName, DateTime newDateOfBirth);

        User GetUser(Guid id);

        IEnumerable<User> GetUsers(bool orderedById = true);
    }
}