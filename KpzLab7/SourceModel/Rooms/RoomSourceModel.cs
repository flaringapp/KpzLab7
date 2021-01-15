using KpzLab7.DAO;
using System.Collections.Generic;
using System.Linq;

namespace KpzLab7.SourceModel.Rooms
{
    public class RoomsSourceModel : IRoomsSourceModel
    {

        private readonly KpzLab7Context context;

        public RoomsSourceModel(KpzLab7Context context)
        {
            this.context = context;
        }

        public List<RoomDataModel> GetRooms()
        {
            return context.Rooms
                .Select(entity => RoomFromEntity(entity)).ToList();
        }

        public RoomDataModel GetRoom(int id)
        {
            var entity = context.Rooms.First(entity => entity.Id == id);
            return RoomFromEntity(entity);
        }

        public int AddRoom(RoomDataModel room)
        {
            var result = context.Rooms.Add(RoomToEntity(room));
            context.SaveChanges();

            return result.Entity.Id;
        }

        public void DeleteRoom(int roomId)
        {
            context.Rooms.Remove(context.Rooms.First(e => e.Id == roomId));
            context.SaveChanges();
        }

        public void EditRoom(RoomDataModel room)
        {
            var entity = context.Rooms.SingleOrDefault(e => e.Id == room.Id);
            SetEntityFromRoom(entity, room);
            context.SaveChanges();
        }

        private RoomDataModel RoomFromEntity(Room entity)
        {
            return new RoomDataModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        private Room RoomToEntity(RoomDataModel room)
        {
            var entity = new Room();
            SetEntityFromRoom(entity, room);
            return entity;
        }

        private void SetEntityFromRoom(Room entity, RoomDataModel room)
        {
            entity.Name = room.Name;
            entity.Description = room.Description;
        }
    }
}
