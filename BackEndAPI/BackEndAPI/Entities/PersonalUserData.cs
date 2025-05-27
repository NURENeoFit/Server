using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class PersonalUserData
    {
        [Key]
        public int PersonalUserDataId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Goal")]
        public int GoalId { get; set; }
        public Goal Goal { get; set; }

        [Required]
        [Range(0, 500)]
        public decimal WeightKg { get; set; }

        [Required]
        [Range(0, 300)]
        public decimal HeightCm { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public ActivityLevel ActivityLevel { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
} 