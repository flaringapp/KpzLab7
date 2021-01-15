using KpzLab7.SourceModel.Rooms;
using System.Collections.Generic;
using System.Linq;

namespace KpzLab7.Repository.Rooms
{
    public class RoomsRepository : IRoomsRepository
    {

        private readonly IRoomsSourceModel sourceModel;

        public RoomsRepository(IRoomsSourceModel sourceModel)
        {
            this.sourceModel = sourceModel;
        }

        public List<RoomModel> GetRooms()
        {
            return sourceModel.GetRooms().ToList()
                .Select(roomData => ParseRoom(roomData))
                .ToList();
        }

        public RoomModel GetRoom(int id)
        {
            var dataModel = sourceModel.GetRoom(id);
            return ParseRoom(dataModel);
        }

        public void AddRoom(RoomModel room)
        {
            var id = sourceModel.AddRoom(EncodeRoom(room));
            room.Id = id;
        }

        public void UpdateRoom(RoomModel room)
        {
            sourceModel.EditRoom(EncodeRoom(room));
        }

        public void DeleteRoom(int id)
        {
            sourceModel.DeleteRoom(id);
        }

        private RoomModel ParseRoom(RoomDataModel room)
        {
            return new RoomModel(room.Id, room.Name, room.Description);
        }

        private RoomDataModel EncodeRoom(RoomModel room)
        {
            return new RoomDataModel()
            {
                Name = room.Name,
                Description = room.Description,
            };
        }
    }
}
