using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Entities
{
    public class FitnessMembership : Membership
    {
        [ForeignKey("FitnessCenter")]
        public int FitnessCenterId { get; set; }
        public Membership Membership { get; set; }
        public FitnessCenter FitnessCenter { get; set; }

    }
} 