namespace KpzLab7.Repository.Rooms
{
    public class RoomModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public RoomModel()
        {
        }

        public RoomModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"User {Id} - {Name} {Description}";
        }
    }
}
