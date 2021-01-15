using Lab6.Data.DB;
using Lab6.Data.DB.UsersSourceModelEFCF.DAO;
using System;
using System.Collections.Generic;
using static Lab6.Data.UserModel;

namespace Lab6.Data.Repository.Users
{
    class UsersRepository : IUsersRepository
    {

        private readonly IUserSourceModel sourceModel;

        public event Action<List<UserModel>> OnUsersUpdated;

        private List<UserModel> _users;

        internal UsersRepository(UsersCFDAO dao)
        {
            sourceModel = new UserSourceModelEFCF(dao);
            GetUsers();
        }

        public List<UserModel> GetUsers()
        {
            if (_users == null)
            {
                var loadedUsers = sourceModel.GetUsers();
                _users = new List<UserModel>();
                foreach (var user in loadedUsers)
                {
                    _users.Add(ParseUser(user));
                }
            }
            return _users;
        }

        public void AddUser(UserModel user)
        {
            var id = sourceModel.AddUser(EncodeUser(user));
            user.Id = id;
            _users.Add(user);
            ProcessUsersUpdated();
        }

        public void UpdateUser(UserModel user)
        {
            sourceModel.EditUser(EncodeUser(user));
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == user.Id)
                {
                    _users[i] = user;
                    ProcessUsersUpdated();
                    return;
                }
            }
        }

        public void DeleteUser(int id)
        {
            sourceModel.DeleteUser(id);
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == id)
                {
                    _users.RemoveAt(i);
                    ProcessUsersUpdated();
                    return;
                }
            }
        }

        private void ProcessUsersUpdated()
        {
            OnUsersUpdated?.Invoke(_users);
        }

        private UserModel ParseUser(UserDataModel user)
        {
            UserType type = UserType.User;
            if (user.Type == "manager") type = UserType.Manager;

            return new UserModel(user.Id, user.Name, user.Surname, user.Email, type);
        }

        private UserDataModel EncodeUser(UserModel user)
        {
            string type = "user";
            if (user.Type == UserType.Manager) type = "manager";

            return new UserDataModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Type = type
            };
        }
    }
}
