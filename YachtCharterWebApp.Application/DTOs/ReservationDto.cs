using System;
using YachtCharterWebApp.Core.Entities;

namespace YachtCharterWebApp.Application.DTOs
{
    public class ReservationDto
    {
        public ReservationDto()
        {

        }

        public ReservationDto(Reservation reservation)
        {
            Id = reservation.Id;
            YachtId = reservation.YachtId;
            StartDate = reservation.StartDate;
            EndDate = reservation.EndDate;
        }

        public int Id { get; set; }
        public int YachtId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
