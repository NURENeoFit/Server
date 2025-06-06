using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GymTrainerMembership : Membership
    {
        [Required]
        public double Price { get; set; }

        //Foreign Key
        public Membership? Membership { get; set; }
        [Required]
        public int GymTrainerId { get; set; }
        [ForeignKey("GymTrainerId")]
        public GymTrainer? GymTrainer { get; set; }
        [ForeignKey("GymCenterId")]
        public GymCenter? GymCenter { get; set; }
        public List<GymTrainerMembershipBooking>? GymMembershipBooking { get; set; } = new List<GymTrainerMembershipBooking>();
    }
} 