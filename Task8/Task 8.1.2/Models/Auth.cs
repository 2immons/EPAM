using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8._1._2.Models
{
    public static class Auth
    {
        public static bool CanLogin(string login, string password)
        {
            return login == "admin" && password == "admin";
        }
    }
}