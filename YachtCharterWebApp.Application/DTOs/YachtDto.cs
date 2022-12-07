using YachtCharterWebApp.Core.Entities;

namespace YachtCharterWebApp.Application.DTOs
{
    public class YachtDto
    {
        public YachtDto()
        {

        }

        public YachtDto(Yacht yacht)
        {
            Id = yacht.Id;
            YachtType = yacht.YachtType.TypeDescription;
            Name = yacht.Name;
            YearProduction = yacht.YearProduction;
            MaxPeople = yacht.MaxPeople;
            RequiredPermission = yacht.RequiredPermission;
            HasEngine = yacht.HasEngine;
            EnginePower = yacht.EnginePower;
            NumberOfCabins = yacht.NumberOfCabins;
            HomePort = yacht.HomePort;
            Description = yacht.Description;
        }

        public int Id { get; set; }
        public string YachtType { get; set; }
        public string Name { get; set; }
        public short YearProduction { get; set; }
        public short MaxPeople { get; set; }
        public bool RequiredPermission { get; set; }
        public bool HasEngine { get; set; }
        public short EnginePower { get; set; }
        public short NumberOfCabins { get; set; }
        public string HomePort { get; set; }
        public string Description { get; set; }
    }
}
