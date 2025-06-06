using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GymCenter
    {
        [Key]
        public int GymCenterId { get; set; }

        [Required]
        [StringLength(100)]
        public string? GymCenterName { get; set; }

        [StringLength(100)]
        public string? GymMembership { get; set; }

        //Foreign Key and navigation properties
        [Required]
        public int SportComplexId { get; set; }
        [ForeignKey("SportComplexId")]
        public SportComplex? SportComplex { get; set; }

        public List<GymMembership>? GymMemberships { get; set; } = new List<GymMembership>();
        public List<GymTrainerMembership>? GymTrainerMemberships { get; set; } = new List<GymTrainerMembership>();
        public List<Gym>? Gyms { get; set; } = new List<Gym>();
    }
} 