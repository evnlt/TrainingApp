using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutineDates");

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("89ec10fa-1e7b-43f2-9edd-a8e1f58c52b8"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("b8188c25-ae5b-44a9-ba04-1ac4e17bed68"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("d1755173-1b1f-4ba5-adb5-5d285b436fa3"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("437294dd-f094-4b16-b812-21ea08edd23d"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("ce63b05a-ea74-43d2-b692-b6f1eb86c54a"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("2900f8c7-054c-4c53-9aff-b8dd25e7dee7"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("583e7329-ff8a-4cac-8d53-dfdd0b90940f"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("b275bb22-41f1-4b2e-b1f2-b4706646d30a"));

            migrationBuilder.AddColumn<string>(
                name: "DateTimes",
                table: "Routines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("176a0e0b-38c7-463d-a59d-17ee04ff0f3b"), 0, true, "Pullups" },
                    { new Guid("858bdf43-cd98-4815-be2f-3be235aa0490"), 0, true, "Ab curl" },
                    { new Guid("92c58b1b-ad38-47c8-b5d3-671ed5f0151f"), 1, false, "Custom 1" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "DateTimes", "Name" },
                values: new object[,]
                {
                    { new Guid("2001029b-a621-4966-9424-28ee2f972a56"), "", "Pull" },
                    { new Guid("62204757-cf51-43bf-afe8-2e76856803e9"), "", "Abs" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("7b9f13eb-b1e0-437a-abb2-7a54a9a4111d"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" },
                    { new Guid("812ecad2-38b5-4f74-a277-96a9832fbbc9"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("d77e11a1-e19c-48c9-944c-69be3c7a05e3"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("176a0e0b-38c7-463d-a59d-17ee04ff0f3b"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("858bdf43-cd98-4815-be2f-3be235aa0490"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("92c58b1b-ad38-47c8-b5d3-671ed5f0151f"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("2001029b-a621-4966-9424-28ee2f972a56"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("62204757-cf51-43bf-afe8-2e76856803e9"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("7b9f13eb-b1e0-437a-abb2-7a54a9a4111d"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("812ecad2-38b5-4f74-a277-96a9832fbbc9"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("d77e11a1-e19c-48c9-944c-69be3c7a05e3"));

            migrationBuilder.DropColumn(
                name: "DateTimes",
                table: "Routines");

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
        }
    }
}
