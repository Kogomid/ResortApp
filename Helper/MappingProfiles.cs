using AutoMapper;
using ResortApp.Dto;
using ResortApp.Model;

namespace ResortApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();

        }
    }
}
