using Epam.UsersAndAwards.BLL.Interfaces;
using Epam.UsersAndAwards.Dependencies;
using System;

namespace Epam.UserAndAwards.PL.Console
{
    public class StartUp
    {
        public static void Main()
        {
            IUsersLogic bllUsers = DependencyResolver.Instanse.UsersLogic;
            IAwardsLogic bllAwards = DependencyResolver.Instanse.AwardsLogic;

            bllUsers.AddUser("Pavel Podoprigora", new DateTime(2002, 10, 2));

            int age = bllUsers.GetUser(Guid.Parse("43018401-cc36-405c-9063-728ab914ac13")).Age;
            System.Console.WriteLine(13);

            // bllAwards.AddAward(Guid.Parse("db2337f4-654b-4048-b65f-b4fe4cb91b10"), "za nashih");

            // bllUsers.AddUser("Andrey Ivanov", new DateTime(2003, 10, 12));

            // bllUsers.AddUser("Alexey Dmitriev", new DateTime(2001, 10, 2));
        }
    }
}