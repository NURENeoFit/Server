using System;
using System.ComponentModel.DataAnnotations;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }

        [Required]
        public GoalType GoalType { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for PersonalUserData
        public ICollection<PersonalUserData> PersonalUsersData { get; set; }
        public ICollection<WorkoutProgram> WorkoutPrograms { get; set; }

    }
} 