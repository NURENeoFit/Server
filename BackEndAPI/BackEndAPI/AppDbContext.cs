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

            // User - PersonalUserData (one-to-one)
            modelBuilder.Entity<User>()
                .HasOne(u => u.PersonalUserData)
                .WithOne(p => p.User)
                .HasForeignKey<PersonalUserData>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // PersonalUserData - Goal (many-to-one)
            modelBuilder.Entity<PersonalUserData>()
                .HasOne(p => p.Goal)
                .WithMany()
                .HasForeignKey(p => p.GoalId)
                .OnDelete(DeleteBehavior.Restrict);

            // PersonalUserData - UserTargetCalculation (one-to-many)
            modelBuilder.Entity<PersonalUserData>()
                .HasMany(p => p.UserTargetCalculations)
                .WithOne(utc => utc.PersonalUserData)
                .HasForeignKey(utc => utc.PersonalUserDataId)
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

            // Inheritance for Trainers (TPT)
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
            modelBuilder.Entity<FitnessTrainer>().ToTable("FitnessTrainers");
            modelBuilder.Entity<GymTrainer>().ToTable("GymTrainers");

            // SportComplex - FitnessCenter (one-to-many)
            modelBuilder.Entity<FitnessCenter>()
                .HasOne(fc => fc.SportComplex)
                .WithMany(sc => sc.FitnessCenters)
                .HasForeignKey(fc => fc.SportComplexId)
                .OnDelete(DeleteBehavior.Cascade);

            // SportComplex - GymCenter (one-to-many)
            modelBuilder.Entity<GymCenter>()
                .HasOne(gc => gc.SportComplex)
                .WithMany(sc => sc.GymCenters)
                .HasForeignKey(gc => gc.SportComplexId)
                .OnDelete(DeleteBehavior.Cascade);

            // SportComplex - WorkingTime (one-to-many)
            modelBuilder.Entity<WorkingTime>()
                .HasOne(wt => wt.SportComplex)
                .WithMany(sc => sc.WorkingTimes)
                .HasForeignKey(wt => wt.SportComplexId)
                .OnDelete(DeleteBehavior.Cascade);

            // Membership inheritance (TPT)
            modelBuilder.Entity<Membership>().ToTable("Memberships");
            modelBuilder.Entity<FitnessMembership>().ToTable("FitnessMemberships");
            modelBuilder.Entity<GymMembership>().ToTable("GymMemberships");
            modelBuilder.Entity<GymTrainerMembership>().ToTable("GymTrainerMemberships");

            // FitnessCenter - FitnessMembership (one-to-many)
            modelBuilder.Entity<FitnessCenter>()
                .HasMany(fc => fc.FitnessMemberships)
                .WithOne(fm => fm.FitnessCenter)
                .HasForeignKey(fm => fm.FitnessCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            // GymCenter - GymMembership (one-to-many)
            modelBuilder.Entity<GymCenter>()
                .HasMany(gc => gc.GymMemberships)
                .WithOne(gm => gm.GymCenter)
                .HasForeignKey(gm => gm.GymCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            // GymMembership - GymTrainer Membership

            // GymTrainerMembership - GymTrainer (many-to-one)
            modelBuilder.Entity<GymTrainerMembership>()
                .HasOne(gtm => gtm.GymTrainer)
                .WithMany()
                .HasForeignKey(gtm => gtm.GymTrainerId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .HasForeignKey(ts => ts.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TrainerSpecialization>()
                .HasOne(ts => ts.Trainer)
                .WithMany()
                .HasForeignKey(ts => ts.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            // GroupSchedule - FitnessTrainer (many-to-one)
            modelBuilder.Entity<GroupSchedule>()
                .HasOne(gs => gs.FitnessTrainer)
                .WithMany()
                .HasForeignKey(gs => gs.FitnessTrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            // GroupSchedule - GroupTraining (many-to-one)
            modelBuilder.Entity<GroupSchedule>()
                .HasOne(gs => gs.GroupTraining)
                .WithMany(gt => gt.GroupSchedules)
                .HasForeignKey(gs => gs.GroupTrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking entities
            modelBuilder.Entity<FitnessMembershipBooking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FitnessMembershipBooking>()
                .HasOne(b => b.FitnessMembership)
                .WithMany()
                .HasForeignKey(b => b.MembershipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GymMembershipBooking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GymMembershipBooking>()
                .HasOne(b => b.GymMembership)
                .WithMany()
                .HasForeignKey(b => b.MembershipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GymTrainerMembershipBooking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GymTrainerMembershipBooking>()
                .HasOne(b => b.GymTrainerMembership)
                .WithMany()
                .HasForeignKey(b => b.MembershipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GroupTrainingBooking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GroupTrainingBooking>()
                .HasOne(b => b.GroupSchedule)
                .WithMany()
                .HasForeignKey(b => b.GroupScheduleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Gym - GymCenter (many-to-one)
            modelBuilder.Entity<Gym>()
                .HasOne(g => g.GymCenter)
                .WithMany()
                .HasForeignKey(g => g.GymCenterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 
