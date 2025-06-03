using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GroupTraining
    {
        [Key]
        public int TrainingId { get; set; }

        [Required]
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        [Required]
        [ForeignKey("FitnessRoom")]
        public int FitnessRoomId { get; set; }
        public FitnessRoom FitnessRoom { get; set; }

        [Required]
        public int Duration { get; set; } // in minutes
    }
} 