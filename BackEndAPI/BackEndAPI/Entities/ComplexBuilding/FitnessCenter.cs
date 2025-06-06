using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class FitnessCenter
    {
        [Key]
        public int FitnessCenterId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FitnessCenterName { get; set; }

        //Foreign Key
        [Required]
        public int SportComplexId { get; set; }
        [ForeignKey("SportComplexId")]
        public SportComplex? SportComplex { get; set; }

        public List<FitnessMembership> FitnessMemberships { get; set; } = new List<FitnessMembership>();
        public List<FitnessMembership> FitnessRooms { get; set; } = new List<FitnessMembership>();

    }
} 