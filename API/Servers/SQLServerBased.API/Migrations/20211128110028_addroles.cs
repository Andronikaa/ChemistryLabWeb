using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLServerBased.API.Migrations
{
    public partial class addroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e6da0a1-8054-408c-ae9d-e6150af2184f", "3ee5e259-2843-4ff7-82a5-3a6acffd6dc8", "FullAccessUser", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e7e6516-64bd-4b2f-a35d-c9dc87671a56", "31548777-0ac1-47ba-b9ef-b82bd1d98dbc", "BasicAccessUser", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e6da0a1-8054-408c-ae9d-e6150af2184f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e7e6516-64bd-4b2f-a35d-c9dc87671a56");
        }
    }
}
