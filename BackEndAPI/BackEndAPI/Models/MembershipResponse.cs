using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Models
{
    public class MembershipResponse
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MembershipType MembershipType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
} 