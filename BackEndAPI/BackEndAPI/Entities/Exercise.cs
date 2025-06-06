using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class Exercise
    {
        [Key]
        [Required]
        public int ExerciseId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        public int Duration { get; set; } 

        [Required]
        public int BurnedCalories { get; set; }

        //foreign key
        [Required]
        public int WorkoutProgramId { get; set; }
        [ForeignKey("WorkoutProgramId")]
        public WorkoutProgram? WorkoutProgram { get; set; }
    }
} 