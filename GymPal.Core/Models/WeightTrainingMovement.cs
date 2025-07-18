using SQLite;

namespace GymPal.Models
{
    public record WeightTrainingMovement : Movement
    {
        [NotNull, MaxLength(40)]
        public required string Name { get; set; }
        public int SetNumber { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}
