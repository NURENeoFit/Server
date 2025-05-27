using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class UserTargetCalculation
    {
        [Key, ForeignKey("Goal")]
        public int GoalId { get; set; }
        public Goal Goal { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public decimal CalculatedNormalCalories { get; set; }

        [Required]
        public decimal CalculatedWeight { get; set; }

        [Required]
        public DateTime CalculatedTargetDate { get; set; }
    }
} 