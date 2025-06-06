using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class Gym
    {
        [Key]
        public int GymId { get; set; }

        [Required]
        [StringLength(100)]
        public string? GymName { get; set; }

        [Required]
        public int GymCenterId { get; set; }
        [ForeignKey("GymCenterId")]
        public GymCenter? GymCenter { get; set; }
    }
} 