using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;

namespace BackEndAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<PersonalUserData> PersonalUserData { get; set; }
        public DbSet<UserTargetCalculation> UserTargetCalculations { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<UserExerciseLog> UserExerciseLogs { get; set; }
        public DbSet<FitnessTrainer> FitnessTrainers { get; set; }
        public DbSet<GymTrainer> GymTrainers { get; set; }
        public DbSet<SportComplex> SportComplexes { get; set; }
        public DbSet<FitnessCenter> FitnessCenters { get; set; }
        public DbSet<GymCenter> GymCenters { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Role (many-to-one)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // PersonalUserData - User (many-to-one)
            modelBuilder.Entity<PersonalUserData>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // PersonalUserData - Goal (many-to-one)
            modelBuilder.Entity<PersonalUserData>()
                .HasOne(p => p.Goal)
                .WithMany(g => g.PersonalUserData)
                .HasForeignKey(p => p.GoalId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserTargetCalculation - User (many-to-one)
            modelBuilder.Entity<UserTargetCalculation>()
                .HasOne(utc => utc.User)
                .WithMany()
                .HasForeignKey(utc => utc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserTargetCalculation - Goal (one-to-one)
            modelBuilder.Entity<UserTargetCalculation>()
                .HasOne(utc => utc.Goal)
                .WithOne()
                .HasForeignKey<UserTargetCalculation>(utc => utc.GoalId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserMeal - PersonalUserData (many-to-one)
            modelBuilder.Entity<UserMeal>()
                .HasOne(um => um.PersonalUserData)
                .WithMany()
                .HasForeignKey(um => um.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // WorkoutProgram - Trainer (many-to-one)
            modelBuilder.Entity<WorkoutProgram>()
                .HasOne(wp => wp.Trainer)
                .WithMany()
                .HasForeignKey(wp => wp.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // WorkoutProgram - Goal (many-to-one)
            modelBuilder.Entity<WorkoutProgram>()
                .HasOne(wp => wp.Goal)
                .WithMany()
                .HasForeignKey(wp => wp.ProgramGoalId)
                .OnDelete(DeleteBehavior.Restrict);

            // Exercise - WorkoutProgram (many-to-one)
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.WorkoutProgram)
                .WithMany(wp => wp.Exercises)
                .HasForeignKey(e => e.WorkoutProgramId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserExerciseLog - PersonalUserData (many-to-one)
            modelBuilder.Entity<UserExerciseLog>()
                .HasOne(uel => uel.PersonalUserData)
                .WithMany()
                .HasForeignKey(uel => uel.PersonalUserDataId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserExerciseLog - Exercise (many-to-one)
            modelBuilder.Entity<UserExerciseLog>()
                .HasOne(uel => uel.Exercise)
                .WithMany()
                .HasForeignKey(uel => uel.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserExerciseLog - WorkoutProgram (many-to-one, optional)
            modelBuilder.Entity<UserExerciseLog>()
                .HasOne(uel => uel.WorkoutProgram)
                .WithMany()
                .HasForeignKey(uel => uel.WorkoutProgramId)
                .OnDelete(DeleteBehavior.SetNull);

            // Inheritance for FitnessTrainer and GymTrainer
            modelBuilder.Entity<FitnessTrainer>().HasBaseType<Trainer>();
            modelBuilder.Entity<GymTrainer>().HasBaseType<Trainer>();

            // SportComplex - FitnessCenter (one-to-many)
            modelBuilder.Entity<FitnessCenter>()
                .HasOne(fc => fc.SportComplex)
                .WithMany(sc => sc.FitnessCenters)
                .HasForeignKey(fc => fc.SportComplexId)
                .OnDelete(DeleteBehavior.Cascade);

            // SportComplex - GymCenter (one-to-many, if needed)
            // If GymCenter should be linked to SportComplex, add a SportComplexId FK to GymCenter and configure here.

            // SportComplex - WorkingTime (one-to-many)
            modelBuilder.Entity<WorkingTime>()
                .HasOne(wt => wt.SportComplex)
                .WithMany(sc => sc.WorkingTimes)
                .HasForeignKey(wt => wt.SportComplexId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 