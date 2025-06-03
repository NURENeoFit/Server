using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{

    public class GymTrainerMembership : Membership
    {
        [ForeignKey("GymTrainer")]
        public int GymTrainerId { get; set; }
        public GymTrainer GymTrainer { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CountOfTraining { get; set; }

    }
} 