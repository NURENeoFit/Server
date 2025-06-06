using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymTrainerRepository : GenericRepository<GymTrainer>, IGymTrainerRepository
    {
        public GymTrainerRepository(AppDbContext context) : base(context) { }

        public async Task<GymTrainer> CreateGymTrainerAsync(GymTrainer trainer)
        {
            // Сначала создаем базового тренера
            var baseTrainer = new Trainer
            {
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Email = trainer.Email,
                Phone = trainer.Phone,
            };

            _context.Trainers.Add(baseTrainer);
            await _context.SaveChangesAsync();

            // Затем создаем спорт-тренера с привязкой к базовому тренеру
            trainer.TrainerId = baseTrainer.TrainerId;
            await _context.GymTrainers.AddAsync(trainer);
            await _context.SaveChangesAsync();

            return trainer;
        }

        public async Task<GymTrainer> UpdateGymTrainerAsync(GymTrainer trainer)
        {
            var existingTrainer = await _context.GymTrainers
                .Include(gt => gt.Trainer)
                .FirstOrDefaultAsync(gt => gt.TrainerId == trainer.TrainerId);

            if (existingTrainer == null)
                return null;

            existingTrainer.Trainer.FirstName = trainer.FirstName;
            existingTrainer.Trainer.LastName = trainer.LastName;
            existingTrainer.Trainer.Email = trainer.Email;
            existingTrainer.Trainer.Phone = trainer.Phone;

            await _context.SaveChangesAsync();
            return existingTrainer;
        }

        public async Task<bool> DeleteGymTrainerAsync(int trainerId)
        {
            var trainer = await _context.GymTrainers
                .Include(gt => gt.Trainer)
                .FirstOrDefaultAsync(gt => gt.TrainerId == trainerId);

            if (trainer == null)
                return false;

            _context.GymTrainers.Remove(trainer);
            _context.Trainers.Remove(trainer.Trainer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GymTrainer> GetGymTrainerByIdAsync(int trainerId)
        {
            return await _context.GymTrainers
                .Include(gt => gt.Trainer)
                .FirstOrDefaultAsync(gt => gt.TrainerId == trainerId);
        }

        public async Task<IEnumerable<GymTrainer>> GetAllGymTrainersAsync()
        {
            return await _context.GymTrainers
                .Include(gt => gt.Trainer)
                .ToListAsync();
        }

    }
} 