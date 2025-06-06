using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class UserTargetCalculation
    {
        [Key]
        [Required]
        public int UserTargetCalculationId { get; set; }

        [Required]
        public decimal CalculatedNormalCalories { get; set; }

        [Required]
        public decimal CalculatedWeight { get; set; }

        [Required]
        public DateTime CalculatedTargetDate { get; set; }

        //Foreign key
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
} 