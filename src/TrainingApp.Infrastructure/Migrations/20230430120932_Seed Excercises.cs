using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedExcercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("87bc36c8-e0e3-49dd-9a1a-41196207b1c9"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("8b4db2a6-b47a-41d9-b53b-f15501a20185"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("d25b4add-4f97-4a3e-9bec-90f7708d6d5e"));

            migrationBuilder.InsertData(
                table: "Excercise",
                columns: new[] { "Id", "Description", "InUse", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("2b9f031c-15bc-47d3-9c20-72352a21387f"), null, true, false, "Custom 1" },
                    { new Guid("d2423242-e556-4e47-8bba-78f90b2f4e40"), null, true, true, "Pullups" },
                    { new Guid("d88f983d-4e0a-4a57-8713-34e33a732f7d"), null, true, true, "Ab curl" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name", "Notes", "WorkoutTemplateId" },
                values: new object[,]
                {
                    { new Guid("7f387b3f-5742-46b8-a1ce-2020b3ab8dcf"), new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull", "This is a note", null },
                    { new Guid("e48882de-d8a7-49cd-a085-67fac0c35e28"), new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs", "This is a note", null },
                    { new Guid("f737b4c6-adb5-41d9-b4a7-f5f7f4bd3a74"), new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs", "This is another note", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercise",
                keyColumn: "Id",
                keyValue: new Guid("2b9f031c-15bc-47d3-9c20-72352a21387f"));

            migrationBuilder.DeleteData(
                table: "Excercise",
                keyColumn: "Id",
                keyValue: new Guid("d2423242-e556-4e47-8bba-78f90b2f4e40"));

            migrationBuilder.DeleteData(
                table: "Excercise",
                keyColumn: "Id",
                keyValue: new Guid("d88f983d-4e0a-4a57-8713-34e33a732f7d"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("7f387b3f-5742-46b8-a1ce-2020b3ab8dcf"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("e48882de-d8a7-49cd-a085-67fac0c35e28"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("f737b4c6-adb5-41d9-b4a7-f5f7f4bd3a74"));

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name", "Notes", "WorkoutTemplateId" },
                values: new object[,]
                {
                    { new Guid("87bc36c8-e0e3-49dd-9a1a-41196207b1c9"), new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs", "This is a note", null },
                    { new Guid("8b4db2a6-b47a-41d9-b53b-f15501a20185"), new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull", "This is a note", null },
                    { new Guid("d25b4add-4f97-4a3e-9bec-90f7708d6d5e"), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs", "This is another note", null }
                });
        }
    }
}
