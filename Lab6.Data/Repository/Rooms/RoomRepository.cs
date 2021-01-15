using Lab6.Data.DB.UsersSourceModelEFCF.DAO;
using System;
using System.Collections.Generic;

namespace Lab6.Data.Repository.Rooms
{
    class RoomRepository : IRoomsRepository
    {

        private readonly UsersCFDAO dao;

        public event Action<List<RoomModel>> OnRoomsUpdated;

        internal RoomRepository(UsersCFDAO dao)
        {
            this.dao = dao;
        }

        public void AddRoom(RoomModel room)
        {
        }

        public void DeleteRoom(int id)
        {
        }

        public List<RoomModel> GetRooms()
        {
            return new List<RoomModel>();
        }

        public void UpdateRoom(RoomModel room)
        {
        }
    }
}
