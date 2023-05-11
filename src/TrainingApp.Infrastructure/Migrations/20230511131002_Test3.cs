using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Excercises_ExcerciseId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "ExcerciseRoutine");

            migrationBuilder.DropIndex(
                name: "IX_Sets_ExcerciseId",
                table: "Sets");

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
    }
}
