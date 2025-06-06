using System.Collections.Generic;

namespace BackEndAPI.Entities
{
    public class FitnessTrainer : Trainer
    {
        //foreign key
        public Trainer? Trainer { get; set; }
        public List<Specialization> Specializations { get; set; } = new List<Specialization>();
        public List<GroupSchedule> GroupSchedules { get; set; } = new List<GroupSchedule>();
    }
} 