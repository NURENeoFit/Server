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
        [Required]
        public int WorkoutProgramId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProgramName { get; set; }

        [Required]
        public int Duration { get; set; } //in days

        [Required]
        public ProgramType ProgramType { get; set; }

        //Foreign key
        [Required]
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer? Trainer { get; set; }

        [Required]
        public int ProgramGoalId { get; set; }
        [ForeignKey("GoalId")]
        public Goal? Goal { get; set; }

        public List<Exercise>? Exercises { get; set; } = new List<Exercise>();
    }
} 