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
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<FitnessMembership> FitnessMemberships { get; set; }
        public DbSet<GymMembership> GymMemberships { get; set; }
        public DbSet<GymTrainerMembership> GymTrainerMemberships { get; set; }
        public DbSet<FitnessRoom> FitnessRooms { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<TrainerSpecialization> TrainerSpecializations { get; set; }
        public DbSet<GroupSchedule> GroupSchedules { get; set; }
        public DbSet<GymTrainerMembershipBooking> GymTrainerMembershipBookings { get; set; }
        public DbSet<FitnessMembershipBooking> FitnessMembershipBookings { get; set; }
        public DbSet<GymMembershipBooking> GymMembershipBookings { get; set; }
        public DbSet<GroupTrainingBooking> GroupTrainingBookings { get; set; }
        public DbSet<Gym> Gyms { get; set; }

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

            // Membership inheritance - Table-per-Type (TPT)
            modelBuilder.Entity<Membership>().ToTable("Memberships");
            modelBuilder.Entity<FitnessMembership>().ToTable("FitnessMemberships");
            modelBuilder.Entity<GymMembership>().ToTable("GymMemberships");
            modelBuilder.Entity<GymTrainerMembership>().ToTable("GymTrainerMemberships");

            // FitnessMembership - FitnessCenter (many-to-one)
            modelBuilder.Entity<FitnessMembership>()
                .HasOne(fm => fm.FitnessCenter)
                .WithMany()
                .HasForeignKey(fm => fm.FitnessCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            // GymMembership - GymCenter (many-to-one)
            modelBuilder.Entity<GymMembership>()
                .HasOne(gm => gm.GymCenter)
                .WithMany()
                .HasForeignKey(gm => gm.GymCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            // GymTrainerMembership - GymTrainer (many-to-one)
            modelBuilder.Entity<GymTrainerMembership>()
                .HasOne(gtm => gtm.GymTrainer)
                .WithMany()
                .HasForeignKey(gtm => gtm.GymTrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Trainer inheritance - Table-per-Type (TPT)
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
            modelBuilder.Entity<FitnessTrainer>().ToTable("FitnessTrainers");
            modelBuilder.Entity<GymTrainer>().ToTable("GymTrainers");

            // FitnessRoom - FitnessCenter (many-to-one)
            modelBuilder.Entity<FitnessRoom>()
                .HasOne(fr => fr.FitnessCenter)
                .WithMany()
                .HasForeignKey(fr => fr.FitnessCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            // GroupTraining - Specialization (many-to-one)
            modelBuilder.Entity<GroupTraining>()
                .HasOne(gt => gt.Specialization)
                .WithMany()
                .HasForeignKey(gt => gt.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade);

            // GroupTraining - FitnessRoom (many-to-one)
            modelBuilder.Entity<GroupTraining>()
                .HasOne(gt => gt.FitnessRoom)
                .WithMany()
                .HasForeignKey(gt => gt.FitnessRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            // TrainerSpecialization (composite key)
            modelBuilder.Entity<TrainerSpecialization>()
                .HasKey(ts => new { ts.SpecializationId, ts.TrainerId });
            modelBuilder.Entity<TrainerSpecialization>()
                .HasOne(ts => ts.Specialization)
                .WithMany()
                .HasForeignKey(ts => ts.SpecializationId);
            modelBuilder.Entity<TrainerSpecialization>()
                .HasOne(ts => ts.Trainer)
                .WithMany()
                .HasForeignKey(ts => ts.TrainerId);

            // GroupSchedule - FitnessTrainer (many-to-one)
            modelBuilder.Entity<GroupSchedule>()
                .HasOne(gs => gs.FitnessTrainer)
                .WithMany()
                .HasForeignKey(gs => gs.FitnessTrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            // GroupSchedule - GroupTraining (many-to-one)
            modelBuilder.Entity<GroupSchedule>()
                .HasOne(gs => gs.GroupTraining)
                .WithMany()
                .HasForeignKey(gs => gs.GroupTrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Composite keys for booking entities
            modelBuilder.Entity<GymTrainerMembershipBooking>()
                .HasKey(b => new { b.UserId, b.MembershipId });
            modelBuilder.Entity<FitnessMembershipBooking>()
                .HasKey(b => new { b.UserId, b.MembershipId });
            modelBuilder.Entity<GymMembershipBooking>()
                .HasKey(b => new { b.UserId, b.MembershipId });

            // Gym - GymCenter (many-to-one)
            modelBuilder.Entity<Gym>()
                .HasOne(g => g.GymCenter)
                .WithMany()
                .HasForeignKey(g => g.GymCenterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 