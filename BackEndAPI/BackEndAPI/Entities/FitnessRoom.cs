using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class FitnessRoom
    {
        [Key]
        public int FitnessRoomId { get; set; }

        [Required]
        [StringLength(100)]
        public string FitnessRoomName { get; set; }

        [Required]
        [ForeignKey("FitnessCenter")]
        public int FitnessCenterId { get; set; }
        public FitnessCenter FitnessCenter { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
} 