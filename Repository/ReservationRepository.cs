using ResortApp.Data;
using ResortApp.Interface;
using ResortApp.Model;

namespace ResortApp.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;
        public ReservationRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Reservation> GetReservations()
        {
            return _context.Reservations.ToList();
        }
        public Reservation GetReservation(int reservationId)
        {
            return _context.Reservations.Where(r => r.ReservationId == reservationId).FirstOrDefault();
        }
        public ICollection<Reservation> GetReservations(int hotelId)
        {
            return _context.Reservations.Where(r => r.HotelId == hotelId).ToList();
        }

        public bool ReservationExists(int reservationId)
        {
            return _context.Reservations.Any(r => r.ReservationId == reservationId);
        }

        public bool CreateReservation(Reservation reservation)
        {
            try
            {
                _context.Add(reservation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            _context.SaveChanges();
        }

        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}