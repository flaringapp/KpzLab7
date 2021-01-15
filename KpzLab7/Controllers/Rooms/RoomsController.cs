using KpzLab7.Repository.Rooms;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KpzLab7.Controllers.Rooms
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : Controller
    {

        private IRoomsRepository repository;

        public RoomsController(IRoomsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetRooms()
        {
            return Ok(
                ToViewModels(
                    repository.GetRooms()
                )
            );
        }

        [HttpGet("rooms/{id}")]
        public ActionResult GetRoom(int id)
        {
            return Ok(
                ToViewModel(
                    repository.GetRoom(id)
                )
            );
        }

        [HttpPost]
        public ActionResult AddRoom(AddRoomViewModel viewModel)
        {
            var model = FromAddViewModel(viewModel);
            repository.AddRoom(model);
            return Ok(
                ToViewModel(model)
            );
        }

        [HttpPut]
        public ActionResult UpdateRoom(RoomViewModel viewModel)
        {
            var model = FromViewModel(viewModel);
            repository.UpdateRoom(model);
            return Ok(
                ToViewModel(model)
            );
        }

        [HttpDelete]
        public ActionResult DeleteRoom(int id)
        {
            repository.DeleteRoom(id);
            return Ok();
        }

        private List<RoomViewModel> ToViewModels(List<RoomModel> models)
        {
            return models.Select(model => ToViewModel(model))
                .ToList();
        }

        private RoomViewModel ToViewModel(RoomModel room)
        {
            return new RoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Description = room.Description,
            };
        }

        private RoomModel FromViewModel(RoomViewModel viewModel)
        {
            return new RoomModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
            };
        }

        private RoomModel FromAddViewModel(AddRoomViewModel viewModel)
        {
            return new RoomModel
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
            };
        }
    }
}