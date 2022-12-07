using YachtCharterWebApp.Core.Entities;

namespace YachtCharterWebApp.Core.Services
{
    public interface IReservationService
    {
        bool AddReservation(Reservation reservation);
    }
}
