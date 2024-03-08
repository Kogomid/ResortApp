using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResortApp.Dto;
using ResortApp.Interface;
using ResortApp.Model;
using ResortApp.Repository;

namespace ResortApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        public HotelController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Hotel>))]
        public IActionResult GetHotels()
        {
            var hotels = _hotelRepository.GetHotels();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(hotels);
        }

        [HttpGet("{hotelId}")]
        [ProducesResponseType(200, Type = typeof(HotelDto))]
        [ProducesResponseType(400)]

        public IActionResult GetHotel(int hotelId)
        {
            var hotel = _mapper.Map<HotelDto>(_hotelRepository.GetHotel(hotelId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HotelDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateHotel([FromBody] HotelDto hotelCreateDto)
        {
            if (hotelCreateDto == null)
                return BadRequest(ModelState);

            var hotelCreate = _mapper.Map<Hotel>(hotelCreateDto);

            var existingHotel = _hotelRepository.GetHotels()
                .Where(h => h.Name == hotelCreate.Name)
                .FirstOrDefault();

            if (existingHotel != null)
            {
                ModelState.AddModelError("", "A hotel with the same name already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_hotelRepository.CreateHotel(hotelCreate))
            {
                ModelState.AddModelError("", $"An error occurred while saving the hotel {hotelCreate.Name}");
                return StatusCode(500, ModelState);
            }

            var hotelDto = _mapper.Map<HotelDto>(hotelCreate);

            return CreatedAtAction(nameof(GetHotel), new { hotelId = hotelDto.HotelId }, hotelDto);
        }

        [HttpPut("{hotelId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateHotel(int hotelId, [FromBody] HotelDto hotelUpdateDto)
        {
            var hotel = _hotelRepository.GetHotel(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            _mapper.Map(hotelUpdateDto, hotel);
            _hotelRepository.UpdateHotel(hotel);

            return NoContent();
        }

        [HttpDelete("{hotelId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteHotel(int hotelId)
        {
            var hotel = _hotelRepository.GetHotel(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            _hotelRepository.DeleteHotel(hotel);

            return NoContent();
        }
    }
}
