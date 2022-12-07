using System;

namespace YachtCharterWebApp.Application.DTOs
{
    public class AddReservationDto
    {
        public AddReservationDto()
        {

        }

        public int YachtId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
