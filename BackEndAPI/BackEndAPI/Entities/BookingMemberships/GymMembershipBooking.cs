using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GymMembershipBooking
    {
        [Key]
        [Required]
        public int GymMembershipBookingId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        // Связь с GymMembership через внешний ключ
        [Required]
        public int GymMembershipId { get; set; }  // Это внешний ключ для связи с GymMembership

        [ForeignKey("GymMembershipId")]
        public GymMembership GymMembership { get; set; }

        // Если GymMembership наследует от Membership, можно сделать еще одно навигационное свойство
        // которое будет ссылаться на Membership
        [ForeignKey("MembershipId")]
        public Membership Membership { get; set; }

        // Внешний ключ, который указывает на родительскую сущность Membership, через GymMembership
        [Required]
        public int MembershipId { get; set; }  // Это внешний ключ для связи с Membership

    }
} 