using System.Collections.Generic;

namespace KpzLab7.SourceModel.Rooms
{
    public interface IRoomsSourceModel
    {

        public List<RoomDataModel> GetRooms();

        public RoomDataModel GetRoom(int id);

        public int AddRoom(RoomDataModel room);

        public void DeleteRoom(int roomId);

        public void EditRoom(RoomDataModel room);

    }
}
