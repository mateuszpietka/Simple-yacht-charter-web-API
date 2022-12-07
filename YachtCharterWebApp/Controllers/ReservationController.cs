using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using YachtCharterWebApp.Application.DTOs;
using YachtCharterWebApp.Core.Entities;
using YachtCharterWebApp.Core.Repositories;
using YachtCharterWebApp.Core.Services;

namespace YachtCharterWebApp.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationService reservationService;

        public ReservationController(IReservationRepository reservationRepository, IReservationService reservationService )
        {
            _reservationRepository = reservationRepository;
            this.reservationService = reservationService;
        }

        [HttpPost]
        public bool Add([FromBody] AddReservationDto reservationDto)
        {
            var reservation = new Reservation()
            {
                YachtId = reservationDto.YachtId,
                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate
            };

            if (reservationService.AddReservation(reservation))
                return true;

            return false;
        }

        [HttpGet]
        public IEnumerable<ReservationDto> GetAll([FromQuery]int yachtId)
        {
            return _reservationRepository.GetByYachtId(yachtId).Select(x => new ReservationDto(x));
        }
    }
}
