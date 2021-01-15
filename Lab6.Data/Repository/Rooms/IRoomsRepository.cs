using System;
using System.Collections.Generic;

namespace Lab6.Data.Repository.Rooms
{
    public interface IRoomsRepository
    {

        event Action<List<RoomModel>> OnRoomsUpdated;

        List<RoomModel> GetRooms();

        void AddRoom(RoomModel room);

        void UpdateRoom(RoomModel room);

        void DeleteRoom(int id);

    }
}
