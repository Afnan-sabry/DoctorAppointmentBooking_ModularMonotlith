using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAvailability.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorAvailabityModuleDB_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DoctorAvailability");

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "DoctorAvailability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSlot",
                schema: "DoctorAvailability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentSlot_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "DoctorAvailability",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSlot_DoctorId",
                schema: "DoctorAvailability",
                table: "AppointmentSlot",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSlot",
                schema: "DoctorAvailability");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "DoctorAvailability");
        }
    }
}
