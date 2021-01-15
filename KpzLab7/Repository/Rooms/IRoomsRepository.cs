using System;
using System.Collections.Generic;

namespace KpzLab7.Repository.Rooms
{
    public interface IRoomsRepository
    {

        List<RoomModel> GetRooms();

        RoomModel GetRoom(int id);

        void AddRoom(RoomModel room);

        void UpdateRoom(RoomModel room);

        void DeleteRoom(int id);

    }
}
