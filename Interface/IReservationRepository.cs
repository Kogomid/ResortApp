using ResortApp.Model;

namespace ResortApp.Interface
{
    public interface IReservationRepository
    {
        ICollection<Reservation> GetReservations();
        Reservation GetReservation(int reservationId);
        ICollection<Reservation> GetReservations(int hotelId);
        bool ReservationExists(int reservationId);
        bool CreateReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);

    }
}
