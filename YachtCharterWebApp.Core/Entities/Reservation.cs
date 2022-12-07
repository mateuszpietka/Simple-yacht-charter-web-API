using System;

namespace YachtCharterWebApp.Core.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int YachtId { get; set; }
        public virtual Yacht Yacht { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
