using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class FitnessMembership : Membership
    {
        [ForeignKey("FitnessCenter")]
        public int FitnessCenterId { get; set; }
        public FitnessCenter FitnessCenter { get; set; }
    }
} 