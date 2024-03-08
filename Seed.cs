using ResortApp.Data;
using ResortApp.Model;

namespace ResortApp
{
    public class Seed
    {
        public void Initialize(DataContext context)
        {
            if (context.Hotels.Any())
            {
                return;
            }

            var hotels = new Hotel[]
            {
                new Hotel { Name = "Hotel1", Location = "Location1", NumberOfRooms = 41, },
                new Hotel { Name = "Hotel2", Location = "Location2", NumberOfRooms = 33, },
                new Hotel { Name = "Hotel3", Location = "Location3", NumberOfRooms = 25, }
            };

            foreach (Hotel hotel in hotels)
            {
                context.Hotels.Add(hotel);
            }

            context.SaveChanges();

            var reservations = new Reservation[]
            {
                new Reservation { GuestName = "John Doe", HotelId = hotels[0].HotelId, CheckInDate = DateTime.Parse("2022-01-01"), CheckOutDate = DateTime.Parse("2024-03-08"), RoomType = "Single", ReservedRooms = 1 },
                new Reservation { GuestName = "Jane Doe", HotelId = hotels[1].HotelId, CheckInDate = DateTime.Parse("2022-02-01"), CheckOutDate = DateTime.Parse("2024-02-08"), RoomType = "Double", ReservedRooms = 1  }, 
                new Reservation { GuestName = "Jim Doe", HotelId = hotels[2].HotelId, CheckInDate = DateTime.Parse("2022-03-01"), CheckOutDate = DateTime.Parse("2024-03-08"), RoomType = "Suite", ReservedRooms = 2  }
            };

            foreach (Reservation reservation in reservations)
            {
                context.Reservations.Add(reservation);
            }

            context.SaveChanges();
        }
    }
}