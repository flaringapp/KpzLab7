using System.Collections.Generic;

namespace KpzLab7.SourceModel.Users
{
    public interface IUsersSourceModel
    {

        public List<UserDataModel> GetUsers();

        public UserDataModel GetUser(int id);

        public int AddUser(UserDataModel user);

        public void DeleteUser(int userId);

        public void EditUser(UserDataModel user);

    }
}
