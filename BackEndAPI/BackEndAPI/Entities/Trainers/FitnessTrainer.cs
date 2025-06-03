using System.Collections.Generic;

namespace BackEndAPI.Entities
{
    public class FitnessTrainer : Trainer
    {
        public ICollection<int> SpecializationIds { get; set; } = new List<int>();
        public ICollection<int> GroupScheduleIds { get; set; } = new List<int>();
    }
} 