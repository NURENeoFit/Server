using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkingTimeController : ControllerBase
    {
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public WorkingTimeController(IWorkingTimeRepository workingTimeRepository)
        {
            _workingTimeRepository = workingTimeRepository;
        }

        [HttpGet("complex/{sportComplexId}")]
        public async Task<ActionResult<IEnumerable<WorkingTime>>> GetAllSchedulesBySportComplex(int sportComplexId)
        {
            var schedules = await _workingTimeRepository.GetAllSchedulesBySportComplexIdAsync(sportComplexId);
            return Ok(schedules);
        }

        [HttpGet("complex/{sportComplexId}/day/{dayOfWeek}")]
        public async Task<ActionResult<WorkingTime>> GetScheduleByDay(int sportComplexId, string dayOfWeek)
        {
            var schedule = await _workingTimeRepository.GetScheduleByDayAsync(sportComplexId, dayOfWeek);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] WorkingTime newSchedule)
        {
            var result = await _workingTimeRepository.AddScheduleAsync(newSchedule);
            if (!result)
                return BadRequest($"The schedule for \"{newSchedule.DayOfWeek}\" already exists for the sports complex {newSchedule.SportComplexId}");

            return CreatedAtAction(nameof(GetScheduleByDay),
                new { sportComplexId = newSchedule.SportComplexId, dayOfWeek = newSchedule.DayOfWeek }, newSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] WorkingTime updatedSchedule)
        {
            var existing = await _workingTimeRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            if (!string.Equals(existing.DayOfWeek, updatedSchedule.DayOfWeek, StringComparison.OrdinalIgnoreCase))
            {
                var conflict = await _workingTimeRepository.GetScheduleByDayAsync(updatedSchedule.SportComplexId, updatedSchedule.DayOfWeek);
                if (conflict != null)
                    return BadRequest($"The schedule for \"{updatedSchedule.DayOfWeek}\" already exists for the sports complex.");
            }

            existing.DayOfWeek = updatedSchedule.DayOfWeek;
            existing.OpenTime = updatedSchedule.OpenTime;
            existing.CloseTime = updatedSchedule.CloseTime;
            existing.SportComplexId = updatedSchedule.SportComplexId;

            _workingTimeRepository.Update(existing);
            await _workingTimeRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _workingTimeRepository.GetByIdAsync(id);
            if (schedule == null)
                return NotFound();

            _workingTimeRepository.Delete(schedule);
            await _workingTimeRepository.SaveAsync();
            return NoContent();
        }
    }
}

