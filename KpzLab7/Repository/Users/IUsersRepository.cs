using System.Collections.Generic;

namespace KpzLab7.Repository.Users
{
    public interface IUsersRepository
    {

        List<UserModel> GetUsers();

        UserModel GetUser(int id);

        void AddUser(UserModel user);

        void UpdateUser(UserModel user);

        void DeleteUser(int id);

    }
}
