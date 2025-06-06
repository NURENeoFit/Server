using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessTrainerRepository : GenericRepository<FitnessTrainer>, IFitnessTrainerRepository
    {
        public FitnessTrainerRepository(AppDbContext context) : base(context) { }

        public async Task<FitnessTrainer> CreateFitnessTrainerAsync(FitnessTrainer trainer)
        {
            var baseTrainer = new Trainer
            {
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Email = trainer.Email,
                Phone = trainer.Phone,
            };

            _context.Trainers.Add(baseTrainer);
            await _context.SaveChangesAsync();

      
            trainer.TrainerId = baseTrainer.TrainerId;
            await _context.FitnessTrainers.AddAsync(trainer);
            await _context.SaveChangesAsync();

            return trainer;
        }

        public async Task<FitnessTrainer> UpdateFitnessTrainerAsync(FitnessTrainer trainer)
        {
            var existingTrainer = await _context.FitnessTrainers
                .Include(ft => ft.Trainer)
                .FirstOrDefaultAsync(ft => ft.TrainerId == trainer.TrainerId);

            if (existingTrainer == null)
                return null;

            // Обновляем базовые данные тренера
            existingTrainer.Trainer.FirstName = trainer.FirstName;
            existingTrainer.Trainer.LastName = trainer.LastName;
            existingTrainer.Trainer.Email = trainer.Email;
            existingTrainer.Trainer.Phone = trainer.Phone;

            // Обновляем специфичные данные фитнес-тренера
            existingTrainer.Specializations = trainer.Specializations;
            existingTrainer.GroupScheduleIds = trainer.GroupScheduleIds;

            await _context.SaveChangesAsync();
            return existingTrainer;
        }

        public async Task<bool> DeleteFitnessTrainerAsync(int trainerId)
        {
            var trainer = await _context.FitnessTrainers
                .Include(ft => ft.Trainer)
                .FirstOrDefaultAsync(ft => ft.TrainerId == trainerId);

            if (trainer == null)
                return false;

            _context.FitnessTrainers.Remove(trainer);
            _context.Trainers.Remove(trainer.Trainer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FitnessTrainer> GetFitnessTrainerByIdAsync(int trainerId)
        {
            return await _context.FitnessTrainers
                .Include(ft => ft.Trainer)
                .FirstOrDefaultAsync(ft => ft.TrainerId == trainerId);
        }

        public async Task<IEnumerable<FitnessTrainer>> GetAllFitnessTrainersAsync()
        {
            return await _context.FitnessTrainers
                .Include(ft => ft.Trainer)
                .ToListAsync();
        }

        public async Task<IEnumerable<FitnessTrainer>> GetFitnessTrainersBySpecializationAsync(int specializationId)
        {
            return await _context.FitnessTrainers
                .Include(ft => ft.Trainer)
                .Include(ft => ft.Specializations)
                .Where(ft => ft.Specializations.Any(s => s.SpecializationId == specializationId))
                .OrderBy(ft => ft.Trainer.LastName)
                .ThenBy(ft => ft.Trainer.FirstName)
                .ToListAsync();
        }

    }
} 