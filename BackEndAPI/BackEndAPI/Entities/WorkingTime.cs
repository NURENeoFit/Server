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
        [StringLength(20)]
        public string? DayOfWeek { get; set; }

        [Required]
        public TimeSpan OpenTime { get; set; }

        [Required]
        public TimeSpan CloseTime { get; set; }

        //Foreign KEy
        [Required]
        public int SportComplexId { get; set; }
        [ForeignKey("SportComplexId")]
        public SportComplex? SportComplex { get; set; }
    }
} 