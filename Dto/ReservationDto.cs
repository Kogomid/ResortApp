namespace ResortApp.Dto
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public int HotelId { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int ReservedRooms { get; set; }
        public string RoomType { get; set; }
    }
}