using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class FitnessMembershipBooking
    {
        [Key]
        [Required]
        public int FitnessMembershipBookingId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public int MembershipId { get; set; }
        [ForeignKey("MembershipId")]
        public Membership? Membership { get; set; }
        public FitnessMembership? FitnessMembership { get; set; }
    }
} 