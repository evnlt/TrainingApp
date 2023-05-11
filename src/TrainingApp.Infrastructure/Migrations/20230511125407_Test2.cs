using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("04feacad-b6d8-487c-94c2-efb8f6a33296"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("2adfc537-4da8-4aff-b011-d302d78077dd"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("ae79b030-e9e3-4f82-9974-6f27776f28e5"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("18c10147-5c5b-44dd-bcef-7a1322d0d65a"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("31574a62-b127-41d6-afa7-f4cf56432cff"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3a1220ea-6a3a-4e9b-84c1-548dfb847319"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("73cd91c2-1996-4b57-a5d7-46e7f7d4c094"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("7b62a307-e217-49a6-bd71-0d970f5b396d"));

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("5be8888e-bc09-4eec-8041-4865c0200720"), 0, true, "Ab curl" },
                    { new Guid("bcf12467-6f76-4eb3-a84a-4087fb8eefe1"), 0, true, "Pullups" },
                    { new Guid("d6e512af-361f-4453-8f2b-4f90ae46ac93"), 1, false, "Custom 1" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f4180933-e21f-4a82-9017-d11a4513322b"), "Abs" },
                    { new Guid("f643d99b-7767-4411-b6ea-a6aae431d651"), "Pull" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("040d9a6b-62ab-4606-b8cd-321dae0462c5"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" },
                    { new Guid("8169ced8-2947-4cd7-8ca0-eb3b604fc532"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("9bc975ce-5e82-47bf-9943-dfac237d4e99"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("5be8888e-bc09-4eec-8041-4865c0200720"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("bcf12467-6f76-4eb3-a84a-4087fb8eefe1"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("d6e512af-361f-4453-8f2b-4f90ae46ac93"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("f4180933-e21f-4a82-9017-d11a4513322b"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("f643d99b-7767-4411-b6ea-a6aae431d651"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("040d9a6b-62ab-4606-b8cd-321dae0462c5"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("8169ced8-2947-4cd7-8ca0-eb3b604fc532"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("9bc975ce-5e82-47bf-9943-dfac237d4e99"));

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("04feacad-b6d8-487c-94c2-efb8f6a33296"), 0, true, "Pullups" },
                    { new Guid("2adfc537-4da8-4aff-b011-d302d78077dd"), 1, false, "Custom 1" },
                    { new Guid("ae79b030-e9e3-4f82-9974-6f27776f28e5"), 0, true, "Ab curl" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18c10147-5c5b-44dd-bcef-7a1322d0d65a"), "Abs" },
                    { new Guid("31574a62-b127-41d6-afa7-f4cf56432cff"), "Pull" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("3a1220ea-6a3a-4e9b-84c1-548dfb847319"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("73cd91c2-1996-4b57-a5d7-46e7f7d4c094"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" },
                    { new Guid("7b62a307-e217-49a6-bd71-0d970f5b396d"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" }
                });
        }
    }
}
