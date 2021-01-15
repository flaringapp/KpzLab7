
namespace Lab6.Data
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public UserType Type { get; set; }

        public UserModel() {
        }

        public UserModel(int id, string name, string surname, string email, UserType type)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Type = type;
        }

        public override string ToString()
        {
            return $"User {Id} - {Name} {Surname} - {Email}";
        }

        public enum UserType
        {
            User,
            Manager
        }
    }
}
