using SQLite;

namespace GymPal.Models
{
    [Table("weight_training_movement")]
    public record WeightTrainingMovement : Movement
    {

        [Column("date"),NotNull]
        public string? Date { get; set; }
        [Column("set_number")]
        public int SetNumber { get; set; }
        [Column("weight")]
        public double Weight { get; set; }
        [Column("reps")]
        public int Reps { get; set; }
    }
}
