using System.ComponentModel.DataAnnotations;

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
    }
} 