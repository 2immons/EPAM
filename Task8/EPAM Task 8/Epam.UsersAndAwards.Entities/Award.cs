using System;

namespace Epam.UsersAndAwards.Entities
{
    public class Award
    {
        private Guid id;
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        private Guid userId;
        public Guid UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string Title { get; set; }

        public Award(Guid userId, string title)
        {
            UserId = userId;
            ID = Guid.NewGuid();
            Title = title;
        }

        public Award()
        {

        }

        public void Edit(string title)
        {
            Title = title;
        }

        public override String ToString()
        {
            return $"\"{Title}\"; award's ID = {ID.ToString().ToUpper()}";
        }
    }
}
