using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class WorkoutProgram
    {
        [Key]
        public int WorkoutTrainingId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProgramName { get; set; }

        [Required]
        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        [Required]
        [ForeignKey("Goal")]
        public int ProgramGoalId { get; set; }
        public Goal Goal { get; set; }

        [Required]
        public int Duration { get; set; } // in days

        [Required]
        public ProgramType ProgramType { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
} 