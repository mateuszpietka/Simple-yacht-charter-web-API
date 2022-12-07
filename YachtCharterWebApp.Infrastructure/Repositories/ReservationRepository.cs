using System.Collections.Generic;
using System.Linq;
using YachtCharterWebApp.Core.Entities;
using YachtCharterWebApp.Core.Repositories;
using YachtCharterWebApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace YachtCharterWebApp.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly YachtsAppDbContext context;

        public ReservationRepository(YachtsAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        public IEnumerable<Reservation> GetByYachtId(int yachtId)
        {
            return context.Reservations.Include(x => x.Yacht).ThenInclude(x => x.YachtType).Where(x => x.YachtId == yachtId);
        }
    }
}
