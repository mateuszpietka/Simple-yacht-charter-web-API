using System.Collections.Generic;
using YachtCharterWebApp.Core.Entities;

namespace YachtCharterWebApp.Core.Repositories
{
    public interface IReservationRepository
    {
        void Add(Reservation reservation);
        IEnumerable<Reservation> GetByYachtId(int yachtId);
    }
}
