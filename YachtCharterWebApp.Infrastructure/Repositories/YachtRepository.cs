using System.Collections.Generic;
using System.Linq;
using YachtCharterWebApp.Core.Entities;
using YachtCharterWebApp.Core.Repositories;
using YachtCharterWebApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace YachtCharterWebApp.Infrastructure.Repositories
{
    public class YachtRepository : IYachtRepository
    {
        private readonly YachtsAppDbContext context;

        public YachtRepository(YachtsAppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Yacht> GetAll()
        {
            return context.Yachts.Include(x => x.YachtType);
        }

        public Yacht GetById(int id)
        {
            return context.Yachts.Include(x => x.YachtType).FirstOrDefault(x => x.Id == id);
        }
    }
}
