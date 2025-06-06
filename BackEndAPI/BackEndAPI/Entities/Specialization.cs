using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Entities
{
    public class Specialization
    {
        [Key]
        [Required]
        public int SpecializationId { get; set; }

        [Required]
        [StringLength(100)]
        public string? SpecializationName { get; set; }

        [StringLength(300)]
        public string? SpecializationDescription { get; set; }

        //Navigation property
        public List<FitnessTrainer> FitnessTrainers { get; set; } = new List<FitnessTrainer>();
    }
} 