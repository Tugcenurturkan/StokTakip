using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StokTakip.Data.Migrations
{
    public partial class ProductActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDefinition");

            migrationBuilder.CreateTable(
                name: "ProductActivity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductActivity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductActivity_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductActivity_ProductTypeId",
                table: "ProductActivity",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductActivity_UserId",
                table: "ProductActivity",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductActivity");

            migrationBuilder.CreateTable(
                name: "ProductDefinition",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDefinition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDefinition_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDefinition_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81a70626-67ca-4266-93c7-1ae06516ba59"),
                column: "ConcurrencyStamp",
                value: "585b1c78-7b91-4f89-bd5e-b4f95b1f267a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ecaf6ccb-a52b-47f2-802d-f14e940e9155"),
                column: "ConcurrencyStamp",
                value: "5b347ab1-d153-4aa2-8daf-750ef9a5567b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f2474c3-7aa0-4878-9e8e-3f99de1583a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8baed5a9-0632-4eb2-8f4d-e7180b08d439", "AQAAAAEAACcQAAAAEG++iYB8a17l+9jCJ0Xvy3Ug61weAH5ovm8nBug5psunxBLlQ7e9Gxp6289gAVToVg==", "19a4fbd5-f153-4f8d-9d0a-fc7549d23ca0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8518ddef-bc48-436b-8fa1-32b34c6206a5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "577b274d-e8e9-412f-ac4e-e56eea624891", "AQAAAAEAACcQAAAAEHR4KiQq45Sozaakq0Eon2u6FELHppMy3UTVzJ8U+Tw41rIPgIPo3guOexABgoJ1XQ==", "29fcc900-86e2-44af-9964-dce0d36bc358" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDefinition_ProductTypeId",
                table: "ProductDefinition",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDefinition_UserId",
                table: "ProductDefinition",
                column: "UserId");
        }
    }
}
