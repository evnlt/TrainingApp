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
                    { new Guid("84dfc342-7bd3-41b7-9320-51fa4dd4c355"), 0, true, "Pullups" },
                    { new Guid("a23d31a7-d837-493a-b2f0-c5d3002146a8"), 0, true, "Ab curl" },
                    { new Guid("a31a4391-c4b7-4295-805c-62870b8810cd"), 1, false, "Custom 1" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("855c75b4-16fb-483c-a571-eb2e68ba5d2e"), "Abs" },
                    { new Guid("9eaf004d-b454-468a-90dd-89dcf8235f0a"), "Pull" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("103947b5-4ef7-44de-a700-8edfbd848d1b"), new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" },
                    { new Guid("47053966-abd2-462a-8100-0d8cc2273baf"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("c3806593-da34-4d26-903e-562e6f15a6c0"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" }
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
