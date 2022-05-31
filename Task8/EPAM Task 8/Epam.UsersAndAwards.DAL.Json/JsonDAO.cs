using Epam.UsersAndAwards.DAL.Interfaces;
using Epam.UsersAndAwards.Entities;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Epam.UsersAndAwards.DAL.Json
{
    public class JsonDAO : IUsersDAO, IAwardsDAO
    {

        private const string JsonFilesPathUsers = @"D:\GitHub\EPAM\Task8\EPAM Task 8\files\users\";
        private const string JsonFilesPathAwards = @"D:\GitHub\EPAM\Task8\EPAM Task 8\files\awards\";

        // сделать списки для юзеров и наград и хранить в одном файле всё

        private string GetFilePathByIdUser(Guid id) => JsonFilesPathUsers + id + ".json";
        private string GetFilePathByIdAward(Guid id) => JsonFilesPathAwards + id + ".json";





        public User AddUser(string name, DateTime dateOfBirth)
        {
            var user = new User(name, dateOfBirth);

            string json = JsonConvert.SerializeObject(user);

            File.WriteAllText(GetFilePathByIdUser(user.ID), json);

            return user;
        }

        public void RemoveUser(Guid id)
        {
            if (File.Exists(GetFilePathByIdUser(id)))
                File.Delete(GetFilePathByIdUser(id));
            else throw new FileNotFoundException(String.Format("File with name {0} at path {1} is not created!", id + ".json", JsonFilesPathUsers));
        }

        public void EditUser(Guid id, string newName, DateTime newDateOfBirth)
        {

            if (!File.Exists(GetFilePathByIdUser(id)))
                throw new FileNotFoundException(String.Format("File with name {0} at path {1} is not created!", id + ".json", JsonFilesPathUsers));

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(GetFilePathByIdUser(id)));

            user.Edit(newName, newDateOfBirth);
            File.WriteAllText(GetFilePathByIdUser(user.ID), JsonConvert.SerializeObject(user));
        }

        public User GetUser(Guid id)
        {
            if (!File.Exists(GetFilePathByIdUser(id)))
                throw new FileNotFoundException(String.Format("File with name {0} at path {1} is not created!", id + ".json"));

            var user = File.ReadAllText(GetFilePathByIdUser(id));

            return JsonConvert.DeserializeObject<User>(user);
        }

        public IEnumerable<User> GetUsers(bool orderedById)
        {
            string[] fileEntries = Directory.GetFiles(JsonFilesPathUsers);
            List<User> users = new List<User>();
            foreach (string fileName in fileEntries)
            {
                User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(fileName));
                Console.WriteLine($"{user.ID}");
                users.Add(user);
            }
            return users;
        }






        public Award GetAward(Guid id)
        {
            if (!File.Exists(GetFilePathByIdAward(id)))
                throw new FileNotFoundException(String.Format("File with name {0} at path {1} is not created!", id + ".json"));

            var award = File.ReadAllText(GetFilePathByIdAward(id));

            return JsonConvert.DeserializeObject<Award>(award);
        }

        public IEnumerable<Award> GetAwards(bool orderedById)
        {
            string[] fileEntries = Directory.GetFiles(JsonFilesPathAwards);
            List<Award> awards = new List<Award>();
            foreach (string fileName in fileEntries)
            {
                Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(fileName));
                Console.WriteLine($"{award.ID}");
                awards.Add(award);
            }
            return awards;
        }

        Award IAwardsDAO.AddAward(Guid userId, string title)
        {
            var award = new Award(userId, title);

            string json = JsonConvert.SerializeObject(award);

            File.WriteAllText(GetFilePathByIdAward(award.ID), json);

            return award;
        }

        void IAwardsDAO.RemoveAward(Guid awardId)
        {
            if (File.Exists(GetFilePathByIdAward(awardId)))
                File.Delete(GetFilePathByIdAward(awardId));
            else throw new FileNotFoundException(String.Format("File with name {0} at path {1} is not created!", awardId + ".json", JsonFilesPathAwards));
        }

        void IAwardsDAO.EditAward(Guid awardId, string title)
        {
            if (!File.Exists(GetFilePathByIdAward(awardId)))
                throw new FileNotFoundException(String.Format("File with name {0} at path {1} is not created!", awardId + ".json", JsonFilesPathAwards));

            Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(GetFilePathByIdAward(awardId)));

            award.Edit(title);
            File.WriteAllText(GetFilePathByIdAward(award.ID), JsonConvert.SerializeObject(award));
        }
    }
}