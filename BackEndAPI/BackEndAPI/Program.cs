using Microsoft.EntityFrameworkCore;
using BackEndAPI;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BackEndAPI.Services;

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
            //builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
            builder.Services.AddScoped<IFitnessTrainerRepository, FitnessTrainerRepository>();
            //builder.Services.AddScoped<IGymTrainerRepository, GymTrainerRepository>();
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
            //builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
            builder.Services.AddScoped<IFitnessMembershipRepository, FitnessMembershipRepository>();
            builder.Services.AddScoped<IGymMembershipRepository, GymMembershipRepository>();
            builder.Services.AddScoped<IGymTrainerMembershipRepository, GymTrainerMembershipRepository>();

            // Configure JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            // Register JwtService
            builder.Services.AddScoped<JwtService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Add authentication middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
