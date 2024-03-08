using Microsoft.AspNetCore.Mvc;
using ResortApp.Dto;
using ResortApp.Interface;
using ResortApp.Model;
using ResortApp.Repository;
using AutoMapper;

namespace ResortApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Reservation>))]
        public IActionResult GetReservations()
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationRepository.GetReservations());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reservations);
        }

        [HttpGet("{reservationId}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservation(int reservationId)
        {
            var reservation = _mapper.Map<ReservationDto>(_reservationRepository.GetReservation(reservationId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reservation);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReservationDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateReservation([FromBody] ReservationDto reservationCreateDto)
        {
            if (reservationCreateDto == null)
                return BadRequest(ModelState);

            var reservationCreate = _mapper.Map<Reservation>(reservationCreateDto);

            var existingReservation = _reservationRepository.GetReservations()
                .Where(r => r.HotelId == reservationCreate.HotelId &&
                            r.CheckInDate < reservationCreate.CheckOutDate &&
                            r.CheckOutDate > reservationCreate.CheckInDate)
                .FirstOrDefault();

            if (existingReservation != null)
            {
                ModelState.AddModelError("", "A reservation for the same hotel and time period already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reservationRepository.CreateReservation(reservationCreate))
            {
                ModelState.AddModelError("", $"An error occurred while saving the reservation for {reservationCreate.GuestName}");
                return StatusCode(500, ModelState);
            }

            var reservationDto = _mapper.Map<ReservationDto>(reservationCreate);

            return CreatedAtAction(nameof(GetReservation), new { reservationId = reservationDto.ReservationId }, reservationDto);
        }

        [HttpPut("{reservationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReservation(int reservationId, [FromBody] ReservationDto reservationUpdateDto)
        {
            if (reservationUpdateDto == null || reservationId != reservationUpdateDto.ReservationId)
                return BadRequest(ModelState);

            var reservation = _reservationRepository.GetReservation(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }

            _mapper.Map(reservationUpdateDto, reservation);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _reservationRepository.UpdateReservation(reservation);

            return NoContent();
        }

        [HttpDelete("{reservationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReservation(int reservationId)
        {
            var reservation = _reservationRepository.GetReservation(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }

            _reservationRepository.DeleteReservation(reservation);
            return NoContent();
        }
    }
}
