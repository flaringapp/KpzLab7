namespace KpzLab7.Repository.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }

        public UserModel()
        {
        }

        public UserModel(int id, string name, string surname, string description)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Description = description;
        }

        public override string ToString()
        {
            return $"User {Id} - {Name} {Surname} - {Description}";
        }

        public enum UserType
        {
            User,
            Manager
        }
    }
}
