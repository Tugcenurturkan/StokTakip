using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StokTakip.Data.Migrations
{
    public partial class StockDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gain",
                table: "ProductActivity");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductActivity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81a70626-67ca-4266-93c7-1ae06516ba59"),
                column: "ConcurrencyStamp",
                value: "b29ba445-430b-49e2-96af-1f931f98a141");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ecaf6ccb-a52b-47f2-802d-f14e940e9155"),
                column: "ConcurrencyStamp",
                value: "26c43fc7-6d84-46ca-8034-1f0ba5b809dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f2474c3-7aa0-4878-9e8e-3f99de1583a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80f7e442-6d24-4118-a826-8ed17da132ce", "AQAAAAEAACcQAAAAEJxdUZ0mfRu6JV5Apvtkkd5yCbHwA3gTzNSChXNGPoT8Uxhr/ieGhNPzXNx57PMzAQ==", "ff66ec4f-f59b-47c7-8f20-2687c7a8745c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8518ddef-bc48-436b-8fa1-32b34c6206a5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2267ae6e-a487-4b9b-86c5-1e285bd08706", "AQAAAAEAACcQAAAAEE8c6c8CdiiSx6AuQZYn9xTrg6isEfayJY475pDF1fwLVoG1k4yMgtWOg7oEZPlfEA==", "1038144e-85b9-497a-9d78-ba9196e7dea9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Gain",
                table: "ProductActivity",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductActivity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81a70626-67ca-4266-93c7-1ae06516ba59"),
                column: "ConcurrencyStamp",
                value: "440f5ee3-f10d-4fbf-b7fc-2fce98dacba3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ecaf6ccb-a52b-47f2-802d-f14e940e9155"),
                column: "ConcurrencyStamp",
                value: "d56da2c8-2cf9-4e7b-91fb-756d4cd1e649");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f2474c3-7aa0-4878-9e8e-3f99de1583a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a4abfde-edb8-4e66-be69-034f9ff92b64", "AQAAAAEAACcQAAAAEKFHySh43I/Z85YJdc5SlgexPlF8TTzrLVcop5xLLLr+cOmMDv7a0E4CpJagCUWiAQ==", "031bb142-ccca-4695-8b5e-9916d214dde3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8518ddef-bc48-436b-8fa1-32b34c6206a5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41d264e5-ba2f-41da-8a94-df582c6653ad", "AQAAAAEAACcQAAAAEAGBuh+87GkC1YDndZDh9vls2JAiBB8LJmmf+Bgkka2Hl8y555TiU5B7bA4VmrDTqg==", "1c0a7bae-290d-4e66-902b-45ed358d1c70" });
        }
    }
}
