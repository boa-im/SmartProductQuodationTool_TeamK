using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartProductQuotationTool.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    PVCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "CartId", "Description", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, null, "", "FX-401R", "B", 3600.0, 1 },
                    { 2, null, "", "FX-401B", "B", 3600.0, 1 },
                    { 3, null, "", "RAX-LCD-LITE", "B", 1400.0, 1 },
                    { 4, null, "", "RAM-1032TZDS", "A", 825.0, 1 },
                    { 5, null, "", "RAM-1032TZDS-CC", "B", 1120.0, 1 },
                    { 6, null, "", "RAX-1048TZDS", "A", 555.0, 1 },
                    { 7, null, "", "RAX-1048TZDS-CC", "B", 830.0, 1 },
                    { 8, null, "", "UIMA4", "A", 295.0, 1 },
                    { 9, null, "", "MGC-CONFIG-KIT4", "B", 425.0, 1 },
                    { 10, null, "", "ALC-480", "B", 1160.0, 1 },
                    { 11, null, "", "PR-300", "B", 255.0, 1 },
                    { 12, null, "", "AGD-048", "B", 815.0, 1 },
                    { 13, null, "", "MGD-32", "B", 1105.0, 1 },
                    { 14, null, "", "PCS-100", "B", 210.0, 1 },
                    { 15, null, "", "MP-3500W", "B", 35.0, 1 },
                    { 16, null, "", "SRM-312R", "C", 780.0, 1 },
                    { 17, null, "", "BB-1001DR", "B", 285.0, 1 },
                    { 18, null, "", "BB-1001D", "A", 285.0, 1 },
                    { 19, null, "", "BB-1001DB", "B", 285.0, 1 },
                    { 20, null, "", "BB-1001DS", "C", 490.0, 1 },
                    { 21, null, "", "BB-1001WPRA", "B", 1075.0, 1 },
                    { 22, null, "", "BB-1001WPA", "B", 1075.0, 1 },
                    { 23, null, "", "BB-1002DR", "B", 515.0, 1 },
                    { 24, null, "", "BB-1002D", "B", 515.0, 1 },
                    { 25, null, "", "BB-1002DB", "B", 515.0, 1 },
                    { 26, null, "", "BB-1002DS", "C", 590.0, 1 },
                    { 27, null, "", "BB-1002WPRA", "B", 1335.0, 1 },
                    { 28, null, "", "BB-1002WPA", "C", 1335.0, 1 },
                    { 29, null, "", "BB-1003DR", "C", 640.0, 1 },
                    { 30, null, "", "BB-1003D", "B", 640.0, 1 },
                    { 31, null, "", "BB-1003DB", "C", 640.0, 1 },
                    { 32, null, "", "BB-1003DS", "C", 900.0, 1 },
                    { 33, null, "", "BB-1008DR", "C", 1590.0, 1 },
                    { 34, null, "", "BB-1008D", "B", 1590.0, 1 },
                    { 35, null, "", "BB-1008DB", "C", 1590.0, 1 },
                    { 36, null, "", "BB-1012DR", "C", 1770.0, 1 },
                    { 37, null, "", "BB-1012D", "C", 1770.0, 1 },
                    { 38, null, "", "BB-1012DB", "C", 1770.0, 1 },
                    { 39, null, "", "MIX-4010", "A", 130.0, 1 },
                    { 40, null, "", "MIX-4010-ISO", "A", 140.0, 1 },
                    { 41, null, "", "MIX-4020", "A", 160.0, 1 },
                    { 42, null, "", "MIX-4020-ISO", "B", 170.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "CartId", "Description", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 43, null, "", "MIX-4030", "A", 110.0, 1 },
                    { 44, null, "", "MIX-4030-ISO", "A", 120.0, 1 },
                    { 45, null, "", "MIX-4001", "A", 28.0, 1 },
                    { 46, null, "", "MIX-4002", "A", 24.0, 1 },
                    { 47, null, "", "MIX-4003-R", "B", 140.0, 1 },
                    { 48, null, "", "MIX-4003-S", "B", 1275.0, 1 },
                    { 49, null, "", "MIX-4090", "A", 600.0, 1 },
                    { 50, null, "", "MIX-4040", "A", 130.0, 1 },
                    { 51, null, "", "MIX-4041", "A", 110.0, 1 },
                    { 52, null, "", "MIX-4042", "B", 195.0, 1 },
                    { 53, null, "", "MIX-4045", "A", 150.0, 1 },
                    { 54, null, "", "MIX-4046", "A", 160.0, 1 },
                    { 55, null, "", "MIX-4050", "A", 170.0, 1 },
                    { 56, null, "", "MIX-4070", "A", 115.0, 1 },
                    { 57, null, "", "MPS-810MP", "N", 190.0, 1 },
                    { 58, null, "", "MPS-802MP", "N", 200.0, 1 },
                    { 59, null, "", "MPS-822MP", "N", 210.0, 1 },
                    { 60, null, "", "BB-800", "N", 45.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "Address2", "City", "CompanyName", "ConcurrencyStamp", "Country", "Discount", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "TwoFactorEnabled", "UserName", "Website" },
                values: new object[,]
                {
                    { "2d20eca2-5488-4f15-83e8-f0ed67f749db", 0, "27 King's College Circle", "", "Waterloo", "University of Toronto", "0dc13c29-21b8-4bac-9afa-48e7aba74e9d", "Canada", 72.0, null, false, false, null, null, null, "password4", null, "444-444-4444", false, "M5S 1A1", "ON", "539510ea-ed67-430b-9107-d78c7ad9b14b", false, "MTL-000004", "https://www.utoronto.ca" },
                    { "9259db75-391d-4249-9776-f4923127d936", 0, "108 University Ave", "", "Waterloo", "Conestoga College", "d021ea82-5032-43fb-bd21-f3c6b3abf66f", "Canada", 68.0, null, false, false, null, null, null, "password2", null, "222-222-2222", false, "N2J 2W2", "ON", "845a842f-31f9-4dd3-b346-7a77524b2677", false, "MTL-000002", "https://www.conestogac.on.ca" },
                    { "b307ccdb-b3b1-411c-89b5-c7f17ceeda07", 0, "1750 Finch Ave E", "", "North York", "Seneca College", "be50c556-ac5f-48f5-95f1-5e1f540d62b1", "Canada", 66.0, null, false, false, null, null, null, "password1", null, "111-111-1111", false, "M2J 2X5", "ON", "5bf7cee4-8635-486e-bd71-aa125ff2b477", false, "MTL-000001", "https://www.senecacollege.ca/home.html" },
                    { "bfe76dd5-13bf-4f87-b227-8d856768907c", 0, "200 University Ave W", "", "Waterloo", "University of Waterloo", "ea363e0a-f8cd-41f8-b388-bfcc46e63027", "Canada", 70.0, null, false, false, null, null, null, "password3", null, "333-333-3333", false, "N2L 3G1", "ON", "58df2bce-2096-4161-a277-a61096efb661", false, "MTL-000003", "https://uwaterloo.ca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId1",
                table: "Carts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CartId",
                table: "Inventories",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
