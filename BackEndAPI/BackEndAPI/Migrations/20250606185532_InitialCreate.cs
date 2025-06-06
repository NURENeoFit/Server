using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MembershipName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MembershipDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecializationDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                });

            migrationBuilder.CreateTable(
                name: "SportComplexes",
                columns: table => new
                {
                    SportComplexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportComplexName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportComplexes", x => x.SportComplexId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalUserDataId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "FitnessCenters",
                columns: table => new
                {
                    FitnessCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessCenterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SportComplexId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCenters", x => x.FitnessCenterId);
                    table.ForeignKey(
                        name: "FK_FitnessCenters_SportComplexes_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplexes",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymCenters",
                columns: table => new
                {
                    GymCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymCenterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GymMembership = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SportComplexId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymCenters", x => x.GymCenterId);
                    table.ForeignKey(
                        name: "FK_GymCenters_SportComplexes_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplexes",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimes",
                columns: table => new
                {
                    WorkingTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SportComplexId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimes", x => x.WorkingTimeId);
                    table.ForeignKey(
                        name: "FK_WorkingTimes_SportComplexes_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplexes",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessTrainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTrainers", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_FitnessTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessTrainers_Trainers_TrainerId1",
                        column: x => x.TrainerId1,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId");
                });

            migrationBuilder.CreateTable(
                name: "GymTrainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTrainers", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_GymTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainers_Trainers_TrainerId1",
                        column: x => x.TrainerId1,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId");
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPrograms",
                columns: table => new
                {
                    WorkoutProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ProgramType = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    ProgramGoalId = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: true),
                    TrainerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPrograms", x => x.WorkoutProgramId);
                    table.ForeignKey(
                        name: "FK_WorkoutPrograms_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId");
                    table.ForeignKey(
                        name: "FK_WorkoutPrograms_Goals_ProgramGoalId",
                        column: x => x.ProgramGoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutPrograms_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutPrograms_Trainers_TrainerId1",
                        column: x => x.TrainerId1,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId");
                });

            migrationBuilder.CreateTable(
                name: "PersonalUserData",
                columns: table => new
                {
                    PersonalUserDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightKg = table.Column<double>(type: "float", nullable: false),
                    HeightCm = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ActivityLevel = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    GoalId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalUserData", x => x.PersonalUserDataId);
                    table.ForeignKey(
                        name: "FK_PersonalUserData_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalUserData_Goals_GoalId1",
                        column: x => x.GoalId1,
                        principalTable: "Goals",
                        principalColumn: "GoalId");
                    table.ForeignKey(
                        name: "FK_PersonalUserData_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessMemberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    MembershipId1 = table.Column<int>(type: "int", nullable: true),
                    FitnessCenterId = table.Column<int>(type: "int", nullable: false),
                    FitnessCenterId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessMemberships", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_FitnessMemberships_FitnessCenters_FitnessCenterId",
                        column: x => x.FitnessCenterId,
                        principalTable: "FitnessCenters",
                        principalColumn: "FitnessCenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessMemberships_FitnessCenters_FitnessCenterId1",
                        column: x => x.FitnessCenterId1,
                        principalTable: "FitnessCenters",
                        principalColumn: "FitnessCenterId");
                    table.ForeignKey(
                        name: "FK_FitnessMemberships_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessMemberships_Memberships_MembershipId1",
                        column: x => x.MembershipId1,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId");
                });

            migrationBuilder.CreateTable(
                name: "FitnessRooms",
                columns: table => new
                {
                    FitnessRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessRoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FitnessCenterId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessRooms", x => x.FitnessRoomId);
                    table.ForeignKey(
                        name: "FK_FitnessRooms_FitnessCenters_FitnessCenterId",
                        column: x => x.FitnessCenterId,
                        principalTable: "FitnessCenters",
                        principalColumn: "FitnessCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymMemberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    MembershipId1 = table.Column<int>(type: "int", nullable: true),
                    GymCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymMemberships", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_GymMemberships_GymCenters_GymCenterId",
                        column: x => x.GymCenterId,
                        principalTable: "GymCenters",
                        principalColumn: "GymCenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymMemberships_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymMemberships_Memberships_MembershipId1",
                        column: x => x.MembershipId1,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId");
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    GymId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GymCenterId = table.Column<int>(type: "int", nullable: false),
                    GymCenterId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.GymId);
                    table.ForeignKey(
                        name: "FK_Gyms_GymCenters_GymCenterId",
                        column: x => x.GymCenterId,
                        principalTable: "GymCenters",
                        principalColumn: "GymCenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gyms_GymCenters_GymCenterId1",
                        column: x => x.GymCenterId1,
                        principalTable: "GymCenters",
                        principalColumn: "GymCenterId");
                });

            migrationBuilder.CreateTable(
                name: "FitnessTrainerSpecialization",
                columns: table => new
                {
                    FitnessTrainersTrainerId = table.Column<int>(type: "int", nullable: false),
                    SpecializationsSpecializationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTrainerSpecialization", x => new { x.FitnessTrainersTrainerId, x.SpecializationsSpecializationId });
                    table.ForeignKey(
                        name: "FK_FitnessTrainerSpecialization_FitnessTrainers_FitnessTrainersTrainerId",
                        column: x => x.FitnessTrainersTrainerId,
                        principalTable: "FitnessTrainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessTrainerSpecialization_Specializations_SpecializationsSpecializationId",
                        column: x => x.SpecializationsSpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerSpecializations",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerSpecializations", x => new { x.SpecializationId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_TrainerSpecializations_FitnessTrainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "FitnessTrainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymTrainerMemberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MembershipId1 = table.Column<int>(type: "int", nullable: true),
                    GymTrainerId = table.Column<int>(type: "int", nullable: false),
                    GymCenterId = table.Column<int>(type: "int", nullable: true),
                    GymTrainerTrainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTrainerMemberships", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_GymTrainerMemberships_GymCenters_GymCenterId",
                        column: x => x.GymCenterId,
                        principalTable: "GymCenters",
                        principalColumn: "GymCenterId");
                    table.ForeignKey(
                        name: "FK_GymTrainerMemberships_GymTrainers_GymTrainerId",
                        column: x => x.GymTrainerId,
                        principalTable: "GymTrainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainerMemberships_GymTrainers_GymTrainerTrainerId",
                        column: x => x.GymTrainerTrainerId,
                        principalTable: "GymTrainers",
                        principalColumn: "TrainerId");
                    table.ForeignKey(
                        name: "FK_GymTrainerMemberships_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainerMemberships_Memberships_MembershipId1",
                        column: x => x.MembershipId1,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId");
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    BurnedCalories = table.Column<int>(type: "int", nullable: false),
                    WorkoutProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_WorkoutPrograms_WorkoutProgramId",
                        column: x => x.WorkoutProgramId,
                        principalTable: "WorkoutPrograms",
                        principalColumn: "WorkoutProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeals",
                columns: table => new
                {
                    UserMealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    PersonalUserDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeals", x => x.UserMealId);
                    table.ForeignKey(
                        name: "FK_UserMeals_PersonalUserData_PersonalUserDataId",
                        column: x => x.PersonalUserDataId,
                        principalTable: "PersonalUserData",
                        principalColumn: "PersonalUserDataId");
                    table.ForeignKey(
                        name: "FK_UserMeals_PersonalUserData_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "PersonalUserData",
                        principalColumn: "PersonalUserDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTargetCalculations",
                columns: table => new
                {
                    UserTargetCalculationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculatedNormalCalories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedTargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalUserDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTargetCalculations", x => x.UserTargetCalculationId);
                    table.ForeignKey(
                        name: "FK_UserTargetCalculations_PersonalUserData_PersonalUserDataId",
                        column: x => x.PersonalUserDataId,
                        principalTable: "PersonalUserData",
                        principalColumn: "PersonalUserDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessMembershipBookings",
                columns: table => new
                {
                    FitnessMembershipBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    FitnessMembershipMembershipId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessMembershipBookings", x => x.FitnessMembershipBookingId);
                    table.ForeignKey(
                        name: "FK_FitnessMembershipBookings_FitnessMemberships_FitnessMembershipMembershipId",
                        column: x => x.FitnessMembershipMembershipId,
                        principalTable: "FitnessMemberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_FitnessMembershipBookings_FitnessMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "FitnessMemberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_FitnessMembershipBookings_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessMembershipBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_FitnessMembershipBookings_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    GropTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    FitnessRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.GropTrainingId);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_FitnessRooms_FitnessRoomId",
                        column: x => x.FitnessRoomId,
                        principalTable: "FitnessRooms",
                        principalColumn: "FitnessRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymMembershipBookings",
                columns: table => new
                {
                    GymMembershipBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    GymMembershipMembershipId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymMembershipBookings", x => x.GymMembershipBookingId);
                    table.ForeignKey(
                        name: "FK_GymMembershipBookings_GymMemberships_GymMembershipMembershipId",
                        column: x => x.GymMembershipMembershipId,
                        principalTable: "GymMemberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_GymMembershipBookings_GymMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "GymMemberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_GymMembershipBookings_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymMembershipBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_GymMembershipBookings_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GymTrainerMembershipBookings",
                columns: table => new
                {
                    GymTrainerMembershipBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    GymTrainerMembershipMembershipId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTrainerMembershipBookings", x => x.GymTrainerMembershipBookingId);
                    table.ForeignKey(
                        name: "FK_GymTrainerMembershipBookings_GymTrainerMemberships_GymTrainerMembershipMembershipId",
                        column: x => x.GymTrainerMembershipMembershipId,
                        principalTable: "GymTrainerMemberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_GymTrainerMembershipBookings_GymTrainerMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "GymTrainerMemberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_GymTrainerMembershipBookings_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainerMembershipBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_GymTrainerMembershipBookings_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GroupSchedules",
                columns: table => new
                {
                    GroupScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FitnessTrainerId = table.Column<int>(type: "int", nullable: false),
                    GroupTrainingId = table.Column<int>(type: "int", nullable: false),
                    FitnessTrainerTrainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSchedules", x => x.GroupScheduleId);
                    table.ForeignKey(
                        name: "FK_GroupSchedules_FitnessTrainers_FitnessTrainerId",
                        column: x => x.FitnessTrainerId,
                        principalTable: "FitnessTrainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSchedules_FitnessTrainers_FitnessTrainerTrainerId",
                        column: x => x.FitnessTrainerTrainerId,
                        principalTable: "FitnessTrainers",
                        principalColumn: "TrainerId");
                    table.ForeignKey(
                        name: "FK_GroupSchedules_GroupTrainings_GroupTrainingId",
                        column: x => x.GroupTrainingId,
                        principalTable: "GroupTrainings",
                        principalColumn: "GropTrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainingBookings",
                columns: table => new
                {
                    GroupTrainingBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupScheduleId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainingBookings", x => x.GroupTrainingBookingId);
                    table.ForeignKey(
                        name: "FK_GroupTrainingBookings_GroupSchedules_GroupScheduleId",
                        column: x => x.GroupScheduleId,
                        principalTable: "GroupSchedules",
                        principalColumn: "GroupScheduleId");
                    table.ForeignKey(
                        name: "FK_GroupTrainingBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_GroupTrainingBookings_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutProgramId",
                table: "Exercises",
                column: "WorkoutProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenters_SportComplexId",
                table: "FitnessCenters",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMembershipBookings_FitnessMembershipMembershipId",
                table: "FitnessMembershipBookings",
                column: "FitnessMembershipMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMembershipBookings_MembershipId",
                table: "FitnessMembershipBookings",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMembershipBookings_UserId",
                table: "FitnessMembershipBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMembershipBookings_UserId1",
                table: "FitnessMembershipBookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMemberships_FitnessCenterId",
                table: "FitnessMemberships",
                column: "FitnessCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMemberships_FitnessCenterId1",
                table: "FitnessMemberships",
                column: "FitnessCenterId1");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessMemberships_MembershipId1",
                table: "FitnessMemberships",
                column: "MembershipId1");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessRooms_FitnessCenterId",
                table: "FitnessRooms",
                column: "FitnessCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessTrainers_TrainerId1",
                table: "FitnessTrainers",
                column: "TrainerId1");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessTrainerSpecialization_SpecializationsSpecializationId",
                table: "FitnessTrainerSpecialization",
                column: "SpecializationsSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSchedules_FitnessTrainerId",
                table: "GroupSchedules",
                column: "FitnessTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSchedules_FitnessTrainerTrainerId",
                table: "GroupSchedules",
                column: "FitnessTrainerTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSchedules_GroupTrainingId",
                table: "GroupSchedules",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingBookings_GroupScheduleId",
                table: "GroupTrainingBookings",
                column: "GroupScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingBookings_UserId",
                table: "GroupTrainingBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingBookings_UserId1",
                table: "GroupTrainingBookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_FitnessRoomId",
                table: "GroupTrainings",
                column: "FitnessRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_SpecializationId",
                table: "GroupTrainings",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_GymCenters_SportComplexId",
                table: "GymCenters",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMembershipBookings_GymMembershipMembershipId",
                table: "GymMembershipBookings",
                column: "GymMembershipMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMembershipBookings_MembershipId",
                table: "GymMembershipBookings",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMembershipBookings_UserId",
                table: "GymMembershipBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMembershipBookings_UserId1",
                table: "GymMembershipBookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_GymCenterId",
                table: "GymMemberships",
                column: "GymCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_MembershipId1",
                table: "GymMemberships",
                column: "MembershipId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_GymCenterId",
                table: "Gyms",
                column: "GymCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_GymCenterId1",
                table: "Gyms",
                column: "GymCenterId1");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMembershipBookings_GymTrainerMembershipMembershipId",
                table: "GymTrainerMembershipBookings",
                column: "GymTrainerMembershipMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMembershipBookings_MembershipId",
                table: "GymTrainerMembershipBookings",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMembershipBookings_UserId",
                table: "GymTrainerMembershipBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMembershipBookings_UserId1",
                table: "GymTrainerMembershipBookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMemberships_GymCenterId",
                table: "GymTrainerMemberships",
                column: "GymCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMemberships_GymTrainerId",
                table: "GymTrainerMemberships",
                column: "GymTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMemberships_GymTrainerTrainerId",
                table: "GymTrainerMemberships",
                column: "GymTrainerTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainerMemberships_MembershipId1",
                table: "GymTrainerMemberships",
                column: "MembershipId1");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainers_TrainerId1",
                table: "GymTrainers",
                column: "TrainerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalUserData_GoalId",
                table: "PersonalUserData",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalUserData_GoalId1",
                table: "PersonalUserData",
                column: "GoalId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalUserData_UserId",
                table: "PersonalUserData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSpecializations_TrainerId",
                table: "TrainerSpecializations",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_PersonalUserDataId",
                table: "UserMeals",
                column: "PersonalUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_UserProfileId",
                table: "UserMeals",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId1",
                table: "Users",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTargetCalculations_PersonalUserDataId",
                table: "UserTargetCalculations",
                column: "PersonalUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_SportComplexId",
                table: "WorkingTimes",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_GoalId",
                table: "WorkoutPrograms",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_ProgramGoalId",
                table: "WorkoutPrograms",
                column: "ProgramGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_TrainerId",
                table: "WorkoutPrograms",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_TrainerId1",
                table: "WorkoutPrograms",
                column: "TrainerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "FitnessMembershipBookings");

            migrationBuilder.DropTable(
                name: "FitnessTrainerSpecialization");

            migrationBuilder.DropTable(
                name: "GroupTrainingBookings");

            migrationBuilder.DropTable(
                name: "GymMembershipBookings");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "GymTrainerMembershipBookings");

            migrationBuilder.DropTable(
                name: "TrainerSpecializations");

            migrationBuilder.DropTable(
                name: "UserMeals");

            migrationBuilder.DropTable(
                name: "UserTargetCalculations");

            migrationBuilder.DropTable(
                name: "WorkingTimes");

            migrationBuilder.DropTable(
                name: "WorkoutPrograms");

            migrationBuilder.DropTable(
                name: "FitnessMemberships");

            migrationBuilder.DropTable(
                name: "GroupSchedules");

            migrationBuilder.DropTable(
                name: "GymMemberships");

            migrationBuilder.DropTable(
                name: "GymTrainerMemberships");

            migrationBuilder.DropTable(
                name: "PersonalUserData");

            migrationBuilder.DropTable(
                name: "FitnessTrainers");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.DropTable(
                name: "GymCenters");

            migrationBuilder.DropTable(
                name: "GymTrainers");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FitnessRooms");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "FitnessCenters");

            migrationBuilder.DropTable(
                name: "SportComplexes");
        }
    }
}
