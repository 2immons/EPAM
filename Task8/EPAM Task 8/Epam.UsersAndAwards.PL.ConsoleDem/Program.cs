using Epam.UsersAndAwards.BLL.Interfaces;
using Epam.UsersAndAwards.Dependencies;
using System;

namespace Epam.UsersAndAwards.PL.ConsoleDem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUsersLogic bllUsers = DependencyResolver.Instanse.UsersLogic;
            IAwardsLogic bllAwards = DependencyResolver.Instanse.AwardsLogic;

            bllUsers.AddUser("Pavel Podoprigora", new DateTime(2002, 10, 2));

            // bllAwards.AddAward(Guid.Parse("db2337f4-654b-4048-b65f-b4fe4cb91b10"), "Награда 2");

            // bllUsers.AddUser("Andrey Ivanov", new DateTime(2003, 10, 12));

            // bllUsers.AddUser("Alexey Dmitriev", new DateTime(2001, 10, 2));
        }
    }
}
