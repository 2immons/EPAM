using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Task_8._1._2.Models
{
    public class CalculatorRolesProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            switch (username)
            {
                case "admin":
                    return new[] { "user", "admin" };
                case "anton":
                    return new[] { "user" };
                default: return new string[] { };
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin")
            {
                return roleName == "user" || roleName == "admin";
            }
            else if(username == "anton")
            {
                return roleName == "user";
            }
            else
            {
                return false;
            }
        }





        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}