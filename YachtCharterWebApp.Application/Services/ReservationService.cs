using System.Linq;
using YachtCharterWebApp.Core.Entities;
using YachtCharterWebApp.Core.Repositories;
using YachtCharterWebApp.Core.Services;

namespace YachtCharterWebApp.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IYachtRepository yachtRepository;

        public ReservationService(IReservationRepository reservationRepository, IYachtRepository yachtRepository)
        {
            _reservationRepository = reservationRepository;
            this.yachtRepository = yachtRepository;
        }

        public bool AddReservation(Reservation reservation)
        {
            if (reservation.StartDate > reservation.EndDate)
                return false;

            reservation.Yacht = yachtRepository.GetById(reservation.YachtId);

            if (reservation.Yacht == null)
                return false;

            var allReservationsForYacht = _reservationRepository.GetByYachtId(reservation.YachtId);

            if (allReservationsForYacht.Any(x => reservation.StartDate >= x.StartDate && reservation.StartDate <= x.EndDate))
                return false;

            _reservationRepository.Add(reservation);

            return true;
        }
    }
}
