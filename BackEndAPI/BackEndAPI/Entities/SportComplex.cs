using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Entities
{
    public class SportComplex
    {
        [Key]
        public int SportComplexId { get; set; }

        [Required]
        [StringLength(100)]
        public string GymName { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string OpeningHours { get; set; }

        public ICollection<FitnessCenter> FitnessCenters { get; set; }
        public ICollection<GymCenter> GymCenters { get; set; }
        public ICollection<WorkingTime> WorkingTimes { get; set; }
    }
} 