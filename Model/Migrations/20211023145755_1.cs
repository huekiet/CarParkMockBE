using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Model.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeBirthdate = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Parkinglots",
                columns: table => new
                {
                    ParkId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkArea = table.Column<long>(type: "bigint", nullable: false),
                    ParkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParkPlace = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ParkPrice = table.Column<long>(type: "bigint", nullable: false),
                    ParkStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkinglots", x => x.ParkId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedTicketNumber = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: true),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    MaximumOnlineTicketNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarColor = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_Cars_Parkinglots_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parkinglots",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingOffices",
                columns: table => new
                {
                    OfficeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndContractDeadline = table.Column<DateTime>(type: "date", nullable: true),
                    OfficeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    OfficePlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficePrice = table.Column<long>(type: "bigint", nullable: true),
                    StartContractDeadline = table.Column<DateTime>(type: "date", nullable: true),
                    TripId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOffices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_BookingOffices_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TripId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Cars_LicensePlate",
                        column: x => x.LicensePlate,
                        principalTable: "Cars",
                        principalColumn: "LicensePlate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Account", "Department", "EmployeeAddress", "EmployeeBirthdate", "EmployeeEmail", "EmployeeName", "EmployeePhone", "Password", "Sex" },
                values: new object[] { 1L, "admin", "employee", "Hanoi", null, "admin@carpark.com", "Admin", "0812345567", "AQAAAAEAACcQAAAAEPo9gWHt8CIooWKKbkjkybP3HOztp+zYGGJipfSf3BaAlBLHPoexhY8ZqjCVLmCXvw==", "0" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingOffices_TripId",
                table: "BookingOffices",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ParkId",
                table: "Cars",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LicensePlate",
                table: "Tickets",
                column: "LicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingOffices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Parkinglots");
        }
    }
}
