using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GroupTrainingBooking
    {
        [Key]
        public int GroupTrainingBookingId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        [Required]
        public int GroupScheduleId { get; set; }
        [ForeignKey("GroupScheduleId")]
        public GroupSchedule? GroupSchedule { get; set; }
    }
} 