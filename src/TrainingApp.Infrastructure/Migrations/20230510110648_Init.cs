using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Excercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    IsBuiltIn = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoutineId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineDates_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExcercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoutineId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExcerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExcercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineExcercises_Excercises_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Excercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutineExcercises_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExcercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExcerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExcercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExcercises_Excercises_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Excercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExcercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkoutExcerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_WorkoutExcercises_WorkoutExcerciseId",
                        column: x => x.WorkoutExcerciseId,
                        principalTable: "WorkoutExcercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "Description", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("509d1054-0f39-4936-aa26-fbc0f108729b"), null, true, "Ab curl" },
                    { new Guid("71e02e1c-6739-4ad4-b11d-8aad12e8f526"), null, false, "Custom 1" },
                    { new Guid("c6cb5002-7f5f-47a2-84c7-761433b32d4b"), null, true, "Pullups" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6622a6ab-dda3-4524-9fe3-0571d1146ca3"), "Abs" },
                    { new Guid("9b3ab829-5f1b-4335-9c93-37f9ac9ca4e0"), "Pull" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("1faca5b3-a8c5-4a4f-9e79-6f619899b932"), new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" },
                    { new Guid("a2f98b18-da6f-43a7-a37d-08d9397d6f5f"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("c7c4e5ad-8883-4458-a983-3c05fb9e58e7"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutineDates_RoutineId",
                table: "RoutineDates",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExcercises_ExcerciseId",
                table: "RoutineExcercises",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExcercises_RoutineId",
                table: "RoutineExcercises",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_WorkoutExcerciseId",
                table: "Sets",
                column: "WorkoutExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExcercises_ExcerciseId",
                table: "WorkoutExcercises",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExcercises_WorkoutId",
                table: "WorkoutExcercises",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutineDates");

            migrationBuilder.DropTable(
                name: "RoutineExcercises");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Routines");

            migrationBuilder.DropTable(
                name: "WorkoutExcercises");

            migrationBuilder.DropTable(
                name: "Excercises");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
