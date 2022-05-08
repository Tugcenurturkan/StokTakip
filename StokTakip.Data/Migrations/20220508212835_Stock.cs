using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StokTakip.Data.Migrations
{
    public partial class Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "474032ba-f1f6-4ab8-9ca8-6bbd6e8f20c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ecaf6ccb-a52b-47f2-802d-f14e940e9155"),
                column: "ConcurrencyStamp",
                value: "5ea476a0-b8ca-47a4-a8db-533dfcd6c0b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f2474c3-7aa0-4878-9e8e-3f99de1583a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96b9bf05-9b94-4fca-8fac-6fbe4fcbf8ae", "AQAAAAEAACcQAAAAEMJ9TIuSva7QfrrUUdBIY8+Pg5h/tuGuXAadNTNL3CX0+6gY5yLkY2Xtr367vCtF+Q==", "92dd939e-ffef-4577-8137-0e931245b2bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8518ddef-bc48-436b-8fa1-32b34c6206a5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b417511-e182-4eec-bc3b-59ea5b4e426e", "AQAAAAEAACcQAAAAED+811MB/JustrXwEjLwug/+3kUQPFiFjgwtQEqDf7aty0c2llT++SJNYzaUkFL3xg==", "847ca77f-697f-4012-ae37-060424ff1a84" });
        }
    }
}
