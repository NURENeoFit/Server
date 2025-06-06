using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; }

        [Required]
        public decimal MembershipPrice { get; set; }

        [Required]
        [StringLength(100)]
        public string MembershipName { get; set; }

        [StringLength(300)]
        public string MembershipDescription { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public MembershipStatus Status { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
} 