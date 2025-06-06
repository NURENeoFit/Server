using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GymMembership : Membership
    {
        public Membership? Membership { get; set; }
        public int GymCenterId { get; set; }
        [ForeignKey("GymCenterId")]
        public GymCenter? GymCenter { get; set; }
        public List<GymMembershipBooking> GymMembershipBookings { get; set; } = new List<GymMembershipBooking>();
    }
} 