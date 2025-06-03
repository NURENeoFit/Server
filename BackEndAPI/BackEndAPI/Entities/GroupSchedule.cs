using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class GroupSchedule
    {
        [Key]
        public int GroupScheduleId { get; set; }

        [Required]
        [ForeignKey("FitnessTrainer")]
        public int FitnessTrainerId { get; set; }
        public FitnessTrainer FitnessTrainer { get; set; }

        [Required]
        [ForeignKey("GroupTraining")]
        public int GroupTrainingId { get; set; }
        public GroupTraining GroupTraining { get; set; }

        [Required]
        public DateTime DateOfDay { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
    }
} 