using System;

namespace Epam.UsersAndAwards.Entities
{
    public class User
    {
        public User(Guid iD, string name, DateTime dateOfBirth)
        {
            ID = iD;
            Name = name;
            DateOfBirth = dateOfBirth.Date;
            Age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-Age))
                Age--;
        }

        public User(string name, DateTime dateOfBirth)
        {
            ID = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateOfBirth.Date;
            Age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-Age))
                Age--;
        }

        public User()
        {

        }

        private Guid id;
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set;  }
        public int Age { get; set; }


        public void Edit(string newName, DateTime newDateOfBirth)
        {
            Name = newName;
            DateOfBirth = newDateOfBirth.Date;
            Age = DateTime.Today.Year - newDateOfBirth.Year;
            if (newDateOfBirth > DateTime.Today.AddYears(-Age))
                Age--;
        }

        public override String ToString()
        {
            return $"{Name}, {DateOfBirth.ToString("d")}, {Age} year(s) old; ID = {ID.ToString().ToUpper()}";
        }

    }
}