namespace BlazorBattles.Shared.DTOs
{
    public class UserUnitDto
    {
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int HitPoints { get; set; }

        public UnitDto Unit { get; set; }
    }
}
