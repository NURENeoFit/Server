using Microsoft.EntityFrameworkCore;
using BackEndAPI;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;

namespace BackEndAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
            builder.Services.AddScoped<IFitnessTrainerRepository, FitnessTrainerRepository>();
            builder.Services.AddScoped<IGymTrainerRepository, GymTrainerRepository>();
            builder.Services.AddScoped<IGoalRepository, GoalRepository>();
            builder.Services.AddScoped<IPersonalUserDataRepository, PersonalUserDataRepository>();
            builder.Services.AddScoped<IUserTargetCalculationRepository, UserTargetCalculationRepository>();
            builder.Services.AddScoped<IUserMealRepository, UserMealRepository>();
            builder.Services.AddScoped<IWorkoutProgramRepository, WorkoutProgramRepository>();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
            builder.Services.AddScoped<IUserExerciseLogRepository, UserExerciseLogRepository>();
            builder.Services.AddScoped<ISportComplexRepository, SportComplexRepository>();
            builder.Services.AddScoped<IFitnessCenterRepository, FitnessCenterRepository>();
            builder.Services.AddScoped<IGymCenterRepository, GymCenterRepository>();
            builder.Services.AddScoped<IWorkingTimeRepository, WorkingTimeRepository>();
            builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
            builder.Services.AddScoped<IFitnessMembershipRepository, FitnessMembershipRepository>();
            builder.Services.AddScoped<IGymMembershipRepository, GymMembershipRepository>();
            builder.Services.AddScoped<IGymTrainerMembershipRepository, GymTrainerMembershipRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
