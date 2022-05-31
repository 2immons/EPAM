using Epam.UsersAndAwards.BLL;
using Epam.UsersAndAwards.BLL.Interfaces;
using Epam.UsersAndAwards.DAL.Interfaces;
using Epam.UsersAndAwards.DAL.Json;

namespace Epam.UsersAndAwards.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETON
        private static DependencyResolver _instance;
        
        public static DependencyResolver Instanse
        {
            get 
            {
                if (_instance == null)
                    return new DependencyResolver();
                return _instance; 
            }
        }
        
        private DependencyResolver()
        {

        }

        #endregion


        private IUsersDAO _usersDAO;
        public IUsersDAO UsersDAO
        {
            get
            {
                if (_usersDAO == null)
                    return new JsonDAO();
                return _usersDAO;
            }
        }


        private IUsersLogic _usersLogic;
        public IUsersLogic UsersLogic
        {
            get
            {
                if (_usersLogic == null)
                    return new UsersLogic(UsersDAO);
                else return _usersLogic;
            }
        }



        private IAwardsDAO _awardsDAO;

        public IAwardsDAO AwardsDAO
        {
            get
            {
                if (_awardsDAO == null)
                    return new JsonDAO();
                return _awardsDAO;
            }
        }


        private IAwardsLogic _awardsLogic;

        public IAwardsLogic AwardsLogic
        {
            get
            {
                if (_awardsDAO == null)
                    return new AwardsLogic(AwardsDAO);
                return (_awardsLogic);
            }
        }

    }
}