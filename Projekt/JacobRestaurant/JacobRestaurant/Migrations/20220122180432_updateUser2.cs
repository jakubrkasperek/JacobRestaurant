using Microsoft.EntityFrameworkCore.Migrations;

namespace JacobRestaurant.Migrations
{
    public partial class updateUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C18ED0EB-3DA8-477B-8B45-3C03B91E67A3",
                column: "ConcurrencyStamp",
                value: "56f5fe7a-cffa-4851-b0bb-afd2dc2a0d62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D6771784-D825-46D8-A159-6714634D096F",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3b0930a3-569d-40c0-a73c-15678cc568a5", "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEBUGXH+HxOMuP5E+U37dx+pCELEXDxOgMa0LNAhO7Yo2GseU+JsHdrbgg2aeBHGMmw==", "890237bc-5d9a-4119-a923-5fa30fc32fa4", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9107a029-6dc4-438b-b260-624a279e5341", null, null, "AQAAAAEAACcQAAAAEAlzUl1PsTKKwJJ2sa2oRYCn7Nh1dr27OHEKSQTw+WNU3y5jD96bDD4uKesum6+WZA==", "64cac578-9fd4-4b1e-ad25-ffe0724f102e", "admin@mail.com" });
        }
    }
}
