namespace ResortApp.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumberOfRooms { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
