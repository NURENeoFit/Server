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

        // ����� � GymMembership ����� ������� ����
        [Required]
        public int GymMembershipId { get; set; }  // ��� ������� ���� ��� ����� � GymMembership

        [ForeignKey("GymMembershipId")]
        public GymMembership GymMembership { get; set; }

        // ���� GymMembership ��������� �� Membership, ����� ������� ��� ���� ������������� ��������
        // ������� ����� ��������� �� Membership
        [ForeignKey("MembershipId")]
        public Membership Membership { get; set; }

        // ������� ����, ������� ��������� �� ������������ �������� Membership, ����� GymMembership
        [Required]
        public int MembershipId { get; set; }  // ��� ������� ���� ��� ����� � Membership

    }
} 