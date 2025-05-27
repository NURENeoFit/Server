using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class UserMeal
    {
        [Key]
        public int UserMealId { get; set; }

        [Required]
        [ForeignKey("PersonalUserData")]
        public int UserProfileId { get; set; }
        public PersonalUserData PersonalUserData { get; set; }

        [Required]
        public MealType Type { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }
    }
} 