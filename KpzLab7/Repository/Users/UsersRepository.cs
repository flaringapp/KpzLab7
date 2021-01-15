using KpzLab7.SourceModel.Users;
using System.Collections.Generic;
using System.Linq;

namespace KpzLab7.Repository.Users
{
    class UsersRepository : IUsersRepository
    {

        private readonly IUsersSourceModel sourceModel;

        public UsersRepository(IUsersSourceModel sourceModel)
        {
            this.sourceModel = sourceModel;
        }

        public List<UserModel> GetUsers()
        {
            return sourceModel.GetUsers()
                .Select(userData => ParseUser(userData))
                .ToList();
        }

        public UserModel GetUser(int id)
        {
            var userData = sourceModel.GetUser(id);
            return ParseUser(userData);
        }

        public void AddUser(UserModel user)
        {
            var id = sourceModel.AddUser(EncodeUser(user));
            user.Id = id;
        }

        public void UpdateUser(UserModel user)
        {
            var dataModel = EncodeUser(user);
            dataModel.Id = user.Id;
            sourceModel.EditUser(dataModel);
        }

        public void DeleteUser(int id)
        {
            sourceModel.DeleteUser(id);
        }

        private UserModel ParseUser(UserDataModel user)
        {
            return new UserModel(user.Id, user.Name, user.Surname, user.Description);
        }

        private UserDataModel EncodeUser(UserModel user)
        {
            return new UserDataModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                Description = user.Description,
            };
        }
    }
}
