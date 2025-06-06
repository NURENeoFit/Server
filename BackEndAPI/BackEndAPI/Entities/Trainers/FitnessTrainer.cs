using System.Collections.Generic;

namespace BackEndAPI.Entities
{
    public class FitnessTrainer : Trainer
    {
        public Trainer Trainer { get; set; }
        public ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
        public ICollection<int> GroupScheduleIds { get; set; } = new List<int>();
    }
} 