using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GroupTraining
    {
        [Key]
        [Required]
        public int GropTrainingId { get; set; }

        [Required]
        public int Duration { get; set; } // in minutes

        //Foreign key
        [Required]
        public int SpecializationId { get; set; }
        [ForeignKey("SpecializationId")]
        public Specialization? Specialization { get; set; }

        [Required]
        public int FitnessRoomId { get; set; }
        [ForeignKey("FitnessRoomId")]
        public FitnessRoom? FitnessRoom { get; set; }
        public List<GroupSchedule>? GroupSchedules { get; set; } = new List<GroupSchedule>();
    }
} 