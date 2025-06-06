using System;
using System.ComponentModel.DataAnnotations;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class Goal
    {
        [Key]
        [Required]
        public int GoalId { get; set; }

        [Required]
        public GoalType GoalType { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        // Navigation property
        public List<PersonalUserData>? PersonalUsersData { get; set; } = new List<PersonalUserData>();
        public List<WorkoutProgram>? WorkoutPrograms { get; set; } = new List<WorkoutProgram>();

    }
} 