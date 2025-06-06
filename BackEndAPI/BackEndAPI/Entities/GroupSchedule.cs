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
        public DateTime DateOfDay { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        //Foreign Key
        [Required]
        public int FitnessTrainerId { get; set; }
        [ForeignKey("FitnessTrainerId")]
        public FitnessTrainer? FitnessTrainer { get; set; }

        [Required]
        public int GroupTrainingId { get; set; }
        [ForeignKey("GroupTrainingId")]
        public GroupTraining? GroupTraining { get; set; }

    }
} 