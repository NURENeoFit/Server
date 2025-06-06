using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(256)]
        public string? HashPassword { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Foreign key
        public int? PersonalUserDataId { get; set; }
        [ForeignKey("PersonalUserDataId")]
        public PersonalUserData? PersonalUserData { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        public List<GymTrainerMembershipBooking>? GymTrainerMembershipBookings { get; set; } = new List<GymTrainerMembershipBooking>();
        public List<GymMembershipBooking>? GymMembershipBookings { get; set; } = new List<GymMembershipBooking>();
        public List<FitnessMembershipBooking>? FitnessMembershipBookings { get; set; } = new List<FitnessMembershipBooking>();
        public List<GroupTrainingBooking>? GroupTrainingBookings { get; set; } = new List<GroupTrainingBooking>();
    }
} 