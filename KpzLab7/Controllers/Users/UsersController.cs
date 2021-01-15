using KpzLab7.Repository.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KpzLab7.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {

        private IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(
                ToViewModels(
                    repository.GetUsers()
                )
            );
        }

        [HttpGet("users/{id}")]
        public ActionResult GetUser(int id)
        {
            return Ok(
                ToViewModel(
                    repository.GetUser(id)
                )
            );
        }

        [HttpPost]
        public ActionResult AddUser(AddUserViewModel viewModel)
        {
            var model = FromAddViewModel(viewModel);
            repository.AddUser(model);
            return Ok(
                ToViewModel(model)
            );
        }

        [HttpPut]
        public ActionResult UpdateUser(UserViewModel viewModel)
        {
            var model = FromViewModel(viewModel);
            repository.UpdateUser(model);
            return Ok(
                ToViewModel(model)
            );
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            repository.DeleteUser(id);
            return Ok();
        }

        private List<UserViewModel> ToViewModels(List<UserModel> models)
        {
            return models.Select(model => ToViewModel(model))
                .ToList();
        }

        private UserViewModel ToViewModel(UserModel user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Description = user.Description,
            };
        }

        private UserModel FromViewModel(UserViewModel viewModel)
        {
            return new UserModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Description = viewModel.Description,
            };
        }

        private UserModel FromAddViewModel(AddUserViewModel viewModel)
        {
            return new UserModel
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Description = viewModel.Description,
            };
        }
    }
}
