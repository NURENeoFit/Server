using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GroupTrainingBooking
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("GroupSchedule")]
        public int GroupScheduleId { get; set; }
        // public GroupSchedule GroupSchedule { get; set; } // Uncomment if GroupSchedule entity exists

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
} 