using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [Required]
        [ForeignKey("WorkoutProgram")]
        public int WorkoutProgramId { get; set; }
        public WorkoutProgram WorkoutProgram { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; } // in minutes

        [Required]
        public int BurnedCalories { get; set; }
    }
} 