using System;
using System.Collections.Generic;

namespace Lab6.Data.Repository.Users
{
    public interface IUsersRepository
    {
        
        event Action<List<UserModel>> OnUsersUpdated;

        List<UserModel> GetUsers();

        void AddUser(UserModel user);

        void UpdateUser(UserModel user);

        void DeleteUser(int id);

    }
}
