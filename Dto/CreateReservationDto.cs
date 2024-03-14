namespace ResortApp.Dto
{
    public class CreateReservationDto
    {
        public int HotelId { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int ReservedRooms { get; set; }
        public string RoomType { get; set; }
    }
}
