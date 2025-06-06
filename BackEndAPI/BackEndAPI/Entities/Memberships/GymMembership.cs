using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GymMembership : Membership
    {
        [ForeignKey("GymCenter")]
        public int GymCenterId { get; set; }
        public GymCenter GymCenter { get; set; }

        [Required]
        public GymMembershipType Type { get; set; }
    }
} 