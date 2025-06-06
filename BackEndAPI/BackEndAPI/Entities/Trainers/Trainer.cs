using System;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Entities
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        public int Experience { get; set; }

        //Foreign key
        public List<WorkoutProgram> WorkoutPrograms { get; set; } = new List<WorkoutProgram>();

    }
} 