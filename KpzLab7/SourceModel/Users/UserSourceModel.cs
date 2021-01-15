using KpzLab7.DAO;
using System.Collections.Generic;
using System.Linq;

namespace KpzLab7.SourceModel.Users
{
    public class UsersSourceModel : IUsersSourceModel
    {

        private readonly KpzLab7Context context;

        public UsersSourceModel(KpzLab7Context context)
        {
            this.context = context;
        }

        public List<UserDataModel> GetUsers()
        {
            return context.Users.ToList()
                .Select(entity => UserFromEntity(entity))
                .ToList();
        }

        public UserDataModel GetUser(int id)
        {
            var entity = context.Users.First(entity => entity.Id == id);
            return UserFromEntity(entity);
        }

        public int AddUser(UserDataModel user)
        {
            var result = context.Users.Add(UserToEntity(user));
            context.SaveChanges();

            return result.Entity.Id;
        }

        public void DeleteUser(int userId)
        {
            context.Users.Remove(context.Users.First(e => e.Id == userId));
            context.SaveChanges();
        }

        public void EditUser(UserDataModel user)
        {
            var entity = context.Users.SingleOrDefault(e => e.Id == user.Id);
            SetEntityFromUser(entity, user);
            context.SaveChanges();
        }

        private UserDataModel UserFromEntity(User entity)
        {
            return new UserDataModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Description = entity.Description
            };
        }

        private User UserToEntity(UserDataModel user)
        {
            var entity = new User();
            SetEntityFromUser(entity, user);
            return entity;
        }

        private void SetEntityFromUser(User entity, UserDataModel user)
        {
            entity.Name = user.Name;
            entity.Surname = user.Surname;
            entity.Description = user.Description;
        }
    }
}
