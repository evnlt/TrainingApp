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
                    ExcersiceType = table.Column<int>(type: "INTEGER", nullable: false),
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
                    RoutineId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExcerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExcercises", x => new { x.RoutineId, x.ExcerciseId });
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
                    Measure = table.Column<int>(type: "INTEGER", nullable: false),
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
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("89ec10fa-1e7b-43f2-9edd-a8e1f58c52b8"), 0, true, "Pullups" },
                    { new Guid("b8188c25-ae5b-44a9-ba04-1ac4e17bed68"), 1, false, "Custom 1" },
                    { new Guid("d1755173-1b1f-4ba5-adb5-5d285b436fa3"), 0, true, "Ab curl" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("437294dd-f094-4b16-b812-21ea08edd23d"), "Pull" },
                    { new Guid("ce63b05a-ea74-43d2-b692-b6f1eb86c54a"), "Abs" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("2900f8c7-054c-4c53-9aff-b8dd25e7dee7"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" },
                    { new Guid("583e7329-ff8a-4cac-8d53-dfdd0b90940f"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("b275bb22-41f1-4b2e-b1f2-b4706646d30a"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" }
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
