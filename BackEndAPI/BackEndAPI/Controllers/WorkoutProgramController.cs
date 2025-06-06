using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;
using BackEndAPI.Entities;
using BackEndAPI.Entities.Enums;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WorkoutProgramController : ControllerBase
    {
        private readonly IWorkoutProgramRepository _workoutProgramRepository;
        public WorkoutProgramController(IWorkoutProgramRepository workoutProgramRepository)
        {
            _workoutProgramRepository = workoutProgramRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TrainerResponse>>> GetAllWorkoutsWithTrainers()
        {
            var programs = await _workoutProgramRepository.GetAllAsync();

            var trainers = programs
                .GroupBy(wp => wp.Trainer)
                .Select(g => new TrainerResponse
                {
                    TrainerId = g.Key.TrainerId,
                    TrainerFirstName = g.Key.FirstName,
                    TrainerLastName = g.Key.LastName,
                    TrainerPhone = g.Key.Phone,
                    TrainerExperience = g.Key.Experience,
                    TrainerEmail = g.Key.Email,
                    TrainerUsername = g.Key.Username,
                    WorkoutPrograms = g.Select(wp => new WorkoutProgramResponse
                    {
                        WorkoutProgramId = wp.WorkoutTrainingId,
                        Name = wp.ProgramName,
                        TrainerId = wp.TrainerId,
                        Duration = wp.Duration,
                        ProgramType = wp.ProgramType.ToString(),
                        Exercises = wp.Exercises.Select(e => new ExerciseResponse
                        {
                            ExerciseId = e.ExerciseId,
                            Name = e.Name,
                            Duration = e.Duration,
                            BurnedCalories = e.BurnedCalories
                        }).ToList()
                    }).ToList()
                });

            return Ok(trainers);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutProgram>>> GetAllWorkoutPrograms()
        {
            var programs = await _workoutProgramRepository.GetAllAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutProgram>> GetWorkoutProgramById(int id)
        {
            var program = await _workoutProgramRepository.GetByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpGet("trainer/{trainerId}")]
        public async Task<ActionResult<IEnumerable<WorkoutProgram>>> GetWorkoutProgramsByTrainerId(int trainerId)
        {
            var programs = await _workoutProgramRepository.GetAllWorkoutProgramsByTrainerIdAsync(trainerId);
            return Ok(programs);
        }

        [HttpGet("goal/{goalId}")]
        public async Task<ActionResult<IEnumerable<WorkoutProgram>>> GetWorkoutsByGoal(int goalId)
        {
            var programs = await _workoutProgramRepository.GetAllWorkoutsByGoalAsync(goalId);
            return Ok(programs);
        }

        [HttpGet("type/{programType}")]
        public async Task<ActionResult<IEnumerable<WorkoutProgram>>> GetWorkoutsByType(ProgramType programType)
        {
            var programs = await _workoutProgramRepository.GetAllWorkoutsByTypeAsync(programType);
            return Ok(programs);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutProgram>> CreateWorkoutProgram([FromBody] WorkoutProgram workoutProgram)
        {
            await _workoutProgramRepository.AddAsync(workoutProgram);
            await _workoutProgramRepository.SaveAsync();
            return CreatedAtAction(nameof(GetWorkoutProgramById), new { id = workoutProgram.WorkoutTrainingId }, workoutProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkoutProgram(int id, [FromBody] WorkoutProgram updateWorkoutProgram)
        {
            var existingProgram = await _workoutProgramRepository.GetByIdAsync(id);
            if (existingProgram == null)
            {
                return NotFound();
            }

            existingProgram.ProgramName = updateWorkoutProgram.ProgramName;
            existingProgram.TrainerId = updateWorkoutProgram.TrainerId;
            existingProgram.ProgramGoalId = updateWorkoutProgram.ProgramGoalId;
            existingProgram.Duration = updateWorkoutProgram.Duration;
            existingProgram.ProgramType = updateWorkoutProgram.ProgramType;
            existingProgram.UpdatedAt = DateTime.UtcNow;

            _workoutProgramRepository.Update(existingProgram);
            await _workoutProgramRepository.SaveAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutProgram(int id)
        {
            var program = await _workoutProgramRepository.GetByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _workoutProgramRepository.Delete(program);
            await _workoutProgramRepository.SaveAsync();

            return NoContent();
        }
    }
}
