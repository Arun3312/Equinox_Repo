using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Equinox.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassCategories",
                columns: table => new
                {
                    ClassCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCategories", x => x.ClassCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCoach = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    EquinoxClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClassPicture = table.Column<string>(type: "TEXT", nullable: false),
                    ClassDay = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    ClassCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.EquinoxClassId);
                    table.ForeignKey(
                        name: "FK_Classes_ClassCategories_ClassCategoryId",
                        column: x => x.ClassCategoryId,
                        principalTable: "ClassCategories",
                        principalColumn: "ClassCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquinoxClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Classes_EquinoxClassId",
                        column: x => x.EquinoxClassId,
                        principalTable: "Classes",
                        principalColumn: "EquinoxClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassCategories",
                columns: new[] { "ClassCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Yoga" },
                    { 2, "HIIT" },
                    { 3, "Boxing" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Chicago Loop", "312-000-1234" },
                    { 2, "Lincoln Park", "312-000-5678" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DOB", "Email", "IsCoach", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", true, "John Doe", "555-111-1234" },
                    { 2, new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", true, "Jane Smith", "555-222-5678" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "EquinoxClassId", "ClassCategoryId", "ClassDay", "ClassPicture", "ClubId", "Name", "Time", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Monday", "hatha.jpg", 1, "Hatha Yoga", "8 AM – 9 AM", 1 },
                    { 2, 2, "Tuesday", "hiit.jpg", 2, "HIIT Junior", "6 PM – 7 PM", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EquinoxClassId",
                table: "Bookings",
                column: "EquinoxClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassCategoryId",
                table: "Classes",
                column: "ClassCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClubId",
                table: "Classes",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UserId",
                table: "Classes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "ClassCategories");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
