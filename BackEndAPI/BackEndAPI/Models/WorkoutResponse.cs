using System.Collections.Generic;

namespace BackEndAPI.Models
{
    public class TrainerResponse
    {
        public int TrainerId { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }
        public string TrainerPhone { get; set; }
        public int TrainerExperience { get; set; }
        public string TrainerEmail { get; set; }
        public string TrainerUsername { get; set; }
        public List<WorkoutProgramResponse> WorkoutPrograms { get; set; }
    }

    public class WorkoutProgramResponse
    {
        public int WorkoutProgramId { get; set; }
        public string Name { get; set; }
        public int TrainerId { get; set; }
        public int Duration { get; set; }
        public string ProgramType { get; set; }
        public List<ExerciseResponse> Exercises { get; set; }
        public string Icon { get; set; }
    }

    public class ExerciseResponse
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int BurnedCalories { get; set; }
    }
} 