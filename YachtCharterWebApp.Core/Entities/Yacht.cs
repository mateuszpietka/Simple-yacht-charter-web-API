namespace YachtCharterWebApp.Core.Entities
{
    public class Yacht
    {
        public int Id { get; set; }
        public int YachtTypeId { get; set; }
        public virtual YachtType YachtType { get; set; }
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
