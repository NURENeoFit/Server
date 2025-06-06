using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Entities
{
    public class UserMeal
    {
        [Key]
        [Required]
        public int UserMealId { get; set; }

        [Required]
        public MealType Type { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        //Foreign Key
        [Required]
        public int UserProfileId { get; set; }
        [ForeignKey("PersonalUserDataId")]
        public PersonalUserData? PersonalUserData { get; set; }
    }
} 