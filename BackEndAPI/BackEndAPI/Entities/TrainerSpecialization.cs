using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class TrainerSpecialization
    {
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public FitnessTrainer? Trainer { get; set; }
    }
} 