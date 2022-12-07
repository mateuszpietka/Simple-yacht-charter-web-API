using System.Collections.Generic;
using YachtCharterWebApp.Core.Entities;

namespace YachtCharterWebApp.Core.Repositories
{
    public interface IYachtRepository
    {
        public IEnumerable<Yacht> GetAll();
        public Yacht GetById(int id);
    }
}
