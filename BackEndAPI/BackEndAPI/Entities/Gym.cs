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
        public string GymName { get; set; }

        [Required]
        [ForeignKey("GymCenter")]
        public int GymCenterId { get; set; }
        public GymCenter GymCenter { get; set; }
    }
} 