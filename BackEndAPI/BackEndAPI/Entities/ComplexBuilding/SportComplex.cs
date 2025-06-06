using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Entities
{
    public class SportComplex
    {
        [Key]
        [Required]
        public int SportComplexId { get; set; }

        [Required]
        [StringLength(100)]
        public string? SportComplexName { get; set; }

        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

        //navigation property
        public List<FitnessCenter> FitnessCenters { get; set; } = new List<FitnessCenter>();
        public List<GymCenter> GymCenters { get; set; } = new List<GymCenter>();
        public List<WorkingTime> WorkingTimes { get; set; } = new List<WorkingTime>();
    }
} 