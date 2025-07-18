using SQLite;

namespace GymPal.Models
{
    public record WeightTrainingMovement : Movement
    {
        
        public required string Date { get; set; }
        public int SetNumber { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}
