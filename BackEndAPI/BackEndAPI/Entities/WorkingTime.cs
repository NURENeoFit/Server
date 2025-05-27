using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Entities
{
    public class WorkingTime
    {
        [Key]
        public int WorkingTimeId { get; set; }

        [Required]
        [ForeignKey("SportComplex")]
        public int SportComplexId { get; set; }
        public SportComplex SportComplex { get; set; }

        [Required]
        [StringLength(20)]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan OpenTime { get; set; }

        [Required]
        public TimeSpan CloseTime { get; set; }
    }
} 