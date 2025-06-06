using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class PersonalUserData
    {
        [Key]
        [Required]
        public int PersonalUserDataId { get; set; }

        [Required]
        [Range(0, 500)]
        public double WeightKg { get; set; }

        [Required]
        [Range(0, 300)]
        public double HeightCm { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public ActivityLevel ActivityLevel { get; set; }

        //Foreign key
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public int GoalId { get; set; }
        [ForeignKey("GoalId")]
        public Goal? Goal { get; set; }

        public List<UserTargetCalculation>? UserTargetCalculations { get; set; } = new List<UserTargetCalculation>();
        public List<UserMeal>? UserMeals { get; set; } = new List<UserMeal>();
    }
} 