using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equinox.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "EquinoxClassId",
                keyValue: 1,
                column: "ClassDay",
                value: "Saturday");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "EquinoxClassId",
                keyValue: 2,
                column: "ClassDay",
                value: "Friday");

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: 1,
                column: "PhoneNumber",
                value: "812-234-4563");

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: 2,
                column: "PhoneNumber",
                value: "630-567-4561");

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Name", "PhoneNumber" },
                values: new object[] { 3, "Wheaton Park", "456-567-4561" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "DOB", "Name", "PhoneNumber" },
                values: new object[] { new DateTime(2000, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter John", "456-678-2345" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "DOB", "Email", "Name", "PhoneNumber" },
                values: new object[] { new DateTime(1978, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "parker@example.com", "Peter Parker", "675-678-2345" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DOB", "Email", "IsCoach", "Name", "PhoneNumber" },
                values: new object[] { 3, new DateTime(1988, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@example.com", true, "Scot Adam", "675-123-2345" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "EquinoxClassId", "ClassCategoryId", "ClassDay", "ClassPicture", "ClubId", "Name", "Time", "UserId" },
                values: new object[] { 3, 2, "Monday", "hiit2.jpg", 3, "HIIT Senior", "6 PM – 7 PM", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "EquinoxClassId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "EquinoxClassId",
                keyValue: 1,
                column: "ClassDay",
                value: "Monday");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "EquinoxClassId",
                keyValue: 2,
                column: "ClassDay",
                value: "Tuesday");

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: 1,
                column: "PhoneNumber",
                value: "312-000-1234");

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: 2,
                column: "PhoneNumber",
                value: "312-000-5678");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "DOB", "Name", "PhoneNumber" },
                values: new object[] { new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "555-111-1234" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "DOB", "Email", "Name", "PhoneNumber" },
                values: new object[] { new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", "Jane Smith", "555-222-5678" });
        }
    }
}
