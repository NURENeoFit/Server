using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class FitnessMembershipBooking
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Membership")]
        public int MembershipId { get; set; }
        public FitnessMembership Membership { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        // public Payment Payment { get; set; } // Uncomment if Payment entity exists
    }
} 