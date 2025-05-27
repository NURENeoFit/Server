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
        public string GymCenterName { get; set; }

        [StringLength(100)]
        public string GymMembership { get; set; }

        [Required]
        [ForeignKey("SportComplex")]
        public int SportComplexId { get; set; }
        public SportComplex SportComplex { get; set; }
    }
} 