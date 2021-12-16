namespace BlazorBattles.Shared.DTOs
{
    public class UserUnitDto
    {
        public string UserId { get; set; }
        public int UnitId { get; set; }
        public int HitPoints { get; set; }

        public UnitDto Unit { get; set; }
    }
}
