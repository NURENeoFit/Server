using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Entities
{
    public class FitnessMembership : Membership
    {
        public Membership? Membership { get; set; }
        [Required]
        public int FitnessCenterId { get; set; }
        [ForeignKey("FitnessCenterId")]
        public FitnessCenter? FitnessCenter { get; set; }
        public List<FitnessMembershipBooking>? FitnessMembershipBookings { get; set; } = new List<FitnessMembershipBooking>();


    }
} 