using Epam.UsersAndAwards.Entities;
using Epam.UsersAndAwards.BLL.Interfaces;
using Epam.UsersAndAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.BLL  
{
    public class UsersLogic : IUsersLogic
    {
        private IUsersDAO _jsonDal;

        public UsersLogic(IUsersDAO jsonDAO)
        {
            _jsonDal = jsonDAO;
        }

        public User AddUser(string name, DateTime dateOfBirth) => _jsonDal.AddUser(name, dateOfBirth);

        public  void RemoveUser(Guid ID) => _jsonDal.RemoveUser(ID);

        public void EditUser(Guid id, string name, DateTime dateOfBirth) => _jsonDal.EditUser(id, name, dateOfBirth);

        public User GetUser(Guid id) => _jsonDal.GetUser(id);

        public IEnumerable<User> GetUsers(bool orderedById = true) => _jsonDal.GetUsers(orderedById);
    }
}