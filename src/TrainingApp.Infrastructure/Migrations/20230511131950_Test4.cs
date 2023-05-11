using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Excercises_ExcerciseId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "ExcerciseRoutine");

            migrationBuilder.DropIndex(
                name: "IX_Sets_ExcerciseId",
                table: "Sets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineExcercises",
                table: "RoutineExcercises");

            migrationBuilder.DropIndex(
                name: "IX_RoutineExcercises_RoutineId",
                table: "RoutineExcercises");

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("2afe4f7e-700a-45dd-b9de-5aec63b93bf6"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("2de0a176-bd86-42f2-882a-4872b48d5f36"));

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: new Guid("7ae7576f-5fb3-4b2f-a0c3-2bf393568376"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("3b754e97-c89e-4a9b-8693-0e5c2cf03ebe"));

            migrationBuilder.DeleteData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: new Guid("b594199e-5d3f-4dae-87d4-d763ab984cab"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("8224795b-7874-4fbd-9e13-011902e08c60"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("d3f6dece-8e28-4c6d-9cc2-cbc1dad03d21"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("fe932301-d99a-47d9-abb9-89af444e1e6d"));

            migrationBuilder.DropColumn(
                name: "ExcerciseId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Excercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineExcercises",
                table: "RoutineExcercises",
                columns: new[] { "RoutineId", "ExcerciseId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineExcercises",
                table: "RoutineExcercises");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ExcerciseId",
                table: "Sets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Excercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineExcercises",
                table: "RoutineExcercises",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExcerciseRoutine",
                columns: table => new
                {
                    ExcercisesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoutinesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseRoutine", x => new { x.ExcercisesId, x.RoutinesId });
                    table.ForeignKey(
                        name: "FK_ExcerciseRoutine_Excercises_ExcercisesId",
                        column: x => x.ExcercisesId,
                        principalTable: "Excercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcerciseRoutine_Routines_RoutinesId",
                        column: x => x.RoutinesId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "ExcersiceType", "IsBuiltIn", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("2afe4f7e-700a-45dd-b9de-5aec63b93bf6"), 0, true, "Ab curl", 0 },
                    { new Guid("2de0a176-bd86-42f2-882a-4872b48d5f36"), 1, false, "Custom 1", 0 },
                    { new Guid("7ae7576f-5fb3-4b2f-a0c3-2bf393568376"), 0, true, "Pullups", 0 }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b754e97-c89e-4a9b-8693-0e5c2cf03ebe"), "Abs" },
                    { new Guid("b594199e-5d3f-4dae-87d4-d763ab984cab"), "Pull" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("8224795b-7874-4fbd-9e13-011902e08c60"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Abs" },
                    { new Guid("d3f6dece-8e28-4c6d-9cc2-cbc1dad03d21"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Abs" },
                    { new Guid("fe932301-d99a-47d9-abb9-89af444e1e6d"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Pull" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExcerciseId",
                table: "Sets",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExcercises_RoutineId",
                table: "RoutineExcercises",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcerciseRoutine_RoutinesId",
                table: "ExcerciseRoutine",
                column: "RoutinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Excercises_ExcerciseId",
                table: "Sets",
                column: "ExcerciseId",
                principalTable: "Excercises",
                principalColumn: "Id");
        }
    }
}
