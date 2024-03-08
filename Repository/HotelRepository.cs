using ResortApp.Data;
using ResortApp.Interface;
using ResortApp.Model;


namespace ResortApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext _context;
        public HotelRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateHotel(Hotel hotel)
        {
            try
            {
                _context.Add(hotel);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Hotel GetHotel(int hotelId)
        {
            return _context.Hotels.Where(h => h.HotelId == hotelId).FirstOrDefault();
        }

        public Hotel GetHotel(string name)
        {
            return _context.Hotels.Where(h => h.Name == name).FirstOrDefault();
        }

        public ICollection<Hotel> GetHotels()
        {
            return _context.Hotels.OrderBy(h => h.Name).ToList();
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.SaveChanges();
        }

        public void DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }
    }
}
