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
        public string FitnessCenterName { get; set; }

        [Required]
        [ForeignKey("SportComplex")]
        public int SportComplexId { get; set; }
        public SportComplex SportComplex { get; set; }
    }
} 