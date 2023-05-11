using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("84dfc342-7bd3-41b7-9320-51fa4dd4c355"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("a23d31a7-d837-493a-b2f0-c5d3002146a8"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("a31a4391-c4b7-4295-805c-62870b8810cd"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("855c75b4-16fb-483c-a571-eb2e68ba5d2e"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("9eaf004d-b454-468a-90dd-89dcf8235f0a"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("103947b5-4ef7-44de-a700-8edfbd848d1b"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("47053966-abd2-462a-8100-0d8cc2273baf"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("c3806593-da34-4d26-903e-562e6f15a6c0"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
