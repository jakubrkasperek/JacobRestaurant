using Microsoft.EntityFrameworkCore.Migrations;

namespace JacobRestaurant.Migrations
{
    public partial class updateFirstUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C18ED0EB-3DA8-477B-8B45-3C03B91E67A3",
                column: "ConcurrencyStamp",
                value: "98816988-ec9d-4bc5-81b5-06ed4d9bf843");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D6771784-D825-46D8-A159-6714634D096F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9107a029-6dc4-438b-b260-624a279e5341", "AQAAAAEAACcQAAAAEAlzUl1PsTKKwJJ2sa2oRYCn7Nh1dr27OHEKSQTw+WNU3y5jD96bDD4uKesum6+WZA==", "64cac578-9fd4-4b1e-ad25-ffe0724f102e", "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C18ED0EB-3DA8-477B-8B45-3C03B91E67A3",
                column: "ConcurrencyStamp",
                value: "436c5204-eb9a-4ac5-a9d2-936954383788");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D6771784-D825-46D8-A159-6714634D096F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "fdb6514c-8b2a-4bde-9c11-f5c49fa1bea3", "AQAAAAEAACcQAAAAEO40byoZT9iDxs6HLFVNYvwbiMr/QxODJVzAdsba8eeHws2shvbrmZxLU2STuQjhKw==", "1a17563f-9ba2-489a-aaea-87367a9c1a13", null });
        }
    }
}
