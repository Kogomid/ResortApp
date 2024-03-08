using ResortApp.Model;

namespace ResortApp.Interface
{
    public interface IHotelRepository
    {
        ICollection<Hotel> GetHotels();
        Hotel GetHotel(int hotelId);
        Hotel GetHotel(string name);
        bool CreateHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(Hotel hotel);
    }
}
