using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class UserExerciseLog
    {
        [Key]
        public int UserExerciseLogId { get; set; }

        [Required]
        [ForeignKey("PersonalUserData")]
        public int PersonalUserDataId { get; set; }
        public PersonalUserData PersonalUserData { get; set; }

        [Required]
        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        [ForeignKey("WorkoutProgram")]
        public int? WorkoutProgramId { get; set; }
        public WorkoutProgram WorkoutProgram { get; set; }

        [Required]
        public DateTime PerformedAt { get; set; }

        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public decimal? Weight { get; set; }
        public int? Duration { get; set; } // in minutes

        [StringLength(500)]
        public string Notes { get; set; }
    }
} 