using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("23d44a33-f522-4a64-8c4e-f6bb877d55a4"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("3baf6f55-69e0-4041-8b66-1150af31e7ce"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("694ef92f-b5d3-4b14-873f-64bbe449a62c"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("0f17e922-6f62-4941-b78b-c40eddb502f2"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("719d06cc-30cc-4c40-954d-e6422bbcd6f7"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("06756c6f-9b19-41ee-a361-71d90bc0514e"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3de03311-56e7-4042-aa02-b73a13f1951a"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("735c2138-66de-4e51-a94e-8d671271d18b"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoutineExcercises");

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("8cf5eb28-6064-4c10-a8ab-3968de781af4"), 1, false, "Custom 1" },
                    { new Guid("90a1197b-84df-488e-b76a-25bc08aaa9e4"), 0, true, "Ab curl" },
                    { new Guid("cd51ee8e-12df-476b-a505-69e7c2dd9137"), 0, true, "Pullups" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("60967842-ffae-47d9-814a-7f76e4b55e86"), "Abs" },
                    { new Guid("ef23aec6-5eb3-4b58-8109-dffa8606c112"), "Pull" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("0916f193-47fa-43cf-9952-9975a207938c"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" },
                    { new Guid("6b8bd380-9692-4b2b-a758-7bd1d4d4f839"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("6d291289-14d3-47f5-8511-d24616f7be20"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("8cf5eb28-6064-4c10-a8ab-3968de781af4"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("90a1197b-84df-488e-b76a-25bc08aaa9e4"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("cd51ee8e-12df-476b-a505-69e7c2dd9137"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("60967842-ffae-47d9-814a-7f76e4b55e86"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("ef23aec6-5eb3-4b58-8109-dffa8606c112"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("0916f193-47fa-43cf-9952-9975a207938c"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("6b8bd380-9692-4b2b-a758-7bd1d4d4f839"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("6d291289-14d3-47f5-8511-d24616f7be20"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RoutineExcercises",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name" },
                values: new object[,]
                {
                    { new Guid("23d44a33-f522-4a64-8c4e-f6bb877d55a4"), 0, true, "Pullups" },
                    { new Guid("3baf6f55-69e0-4041-8b66-1150af31e7ce"), 0, true, "Ab curl" },
                    { new Guid("694ef92f-b5d3-4b14-873f-64bbe449a62c"), 1, false, "Custom 1" }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f17e922-6f62-4941-b78b-c40eddb502f2"), "Pull" },
                    { new Guid("719d06cc-30cc-4c40-954d-e6422bbcd6f7"), "Abs" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("06756c6f-9b19-41ee-a361-71d90bc0514e"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("3de03311-56e7-4042-aa02-b73a13f1951a"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" },
                    { new Guid("735c2138-66de-4e51-a94e-8d671271d18b"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" }
                });
        }
    }
}
