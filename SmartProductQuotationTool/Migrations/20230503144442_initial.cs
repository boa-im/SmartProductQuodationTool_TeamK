using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartProductQuotationTool.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountRate = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PVCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "Description", "Level", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, "", 1, "FX-401R", "B", 3600.0, 1 },
                    { 2, "", 1, "FX-401B", "B", 3600.0, 1 },
                    { 3, "", 2, "RAX-LCD-LITE", "B", 1400.0, 1 },
                    { 4, "", 2, "RAM-1032TZDS", "A", 825.0, 1 },
                    { 5, "", 2, "RAM-1032TZDS-CC", "B", 1120.0, 1 },
                    { 6, "", 2, "RAX-1048TZDS", "A", 555.0, 1 },
                    { 7, "", 2, "RAX-1048TZDS-CC", "B", 830.0, 1 },
                    { 8, "", 3, "UIMA4", "A", 295.0, 1 },
                    { 9, "", 3, "MGC-CONFIG-KIT4", "B", 425.0, 1 },
                    { 10, "", 4, "ALC-480", "B", 1160.0, 1 },
                    { 11, "", 4, "PR-300", "B", 255.0, 1 },
                    { 12, "", 4, "AGD-048", "B", 815.0, 1 },
                    { 13, "", 4, "MGD-32", "B", 1105.0, 1 },
                    { 14, "", 4, "PCS-100", "B", 210.0, 1 },
                    { 15, "", 4, "MP-3500W", "B", 35.0, 1 },
                    { 16, "", 4, "SRM-312R", "C", 780.0, 1 },
                    { 17, "", 5, "BB-1001DR", "B", 285.0, 1 },
                    { 18, "", 5, "BB-1001D", "A", 285.0, 1 },
                    { 19, "", 5, "BB-1001DB", "B", 285.0, 1 },
                    { 20, "", 5, "BB-1001DS", "C", 490.0, 1 },
                    { 21, "", 5, "BB-1001WPRA", "B", 1075.0, 1 },
                    { 22, "", 5, "BB-1001WPA", "B", 1075.0, 1 },
                    { 23, "", 5, "BB-1002DR", "B", 515.0, 1 },
                    { 24, "", 5, "BB-1002D", "B", 515.0, 1 },
                    { 25, "", 5, "BB-1002DB", "B", 515.0, 1 },
                    { 26, "", 5, "BB-1002DS", "C", 590.0, 1 },
                    { 27, "", 5, "BB-1002WPRA", "B", 1335.0, 1 },
                    { 28, "", 5, "BB-1002WPA", "C", 1335.0, 1 },
                    { 29, "", 5, "BB-1003DR", "C", 640.0, 1 },
                    { 30, "", 5, "BB-1003D", "B", 640.0, 1 },
                    { 31, "", 5, "BB-1003DB", "C", 640.0, 1 },
                    { 32, "", 5, "BB-1003DS", "C", 900.0, 1 },
                    { 33, "", 5, "BB-1008DR", "C", 1590.0, 1 },
                    { 34, "", 5, "BB-1008D", "B", 1590.0, 1 },
                    { 35, "", 5, "BB-1008DB", "C", 1590.0, 1 },
                    { 36, "", 5, "BB-1012DR", "C", 1770.0, 1 },
                    { 37, "", 5, "BB-1012D", "C", 1770.0, 1 },
                    { 38, "", 5, "BB-1012DB", "C", 1770.0, 1 },
                    { 39, "", 6, "MIX-4010", "A", 130.0, 1 },
                    { 40, "", 6, "MIX-4010-ISO", "A", 140.0, 1 },
                    { 41, "", 6, "MIX-4020", "A", 160.0, 1 },
                    { 42, "", 6, "MIX-4020-ISO", "B", 170.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "Description", "Level", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 43, "", 6, "MIX-4030", "A", 110.0, 1 },
                    { 44, "", 6, "MIX-4030-ISO", "A", 120.0, 1 },
                    { 45, "", 6, "MIX-4001", "A", 28.0, 1 },
                    { 46, "", 6, "MIX-4002", "A", 24.0, 1 },
                    { 47, "", 6, "MIX-4003-R", "B", 140.0, 1 },
                    { 48, "", 6, "MIX-4003-S", "B", 1275.0, 1 },
                    { 49, "", 6, "MIX-4090", "A", 600.0, 1 },
                    { 50, "", 6, "MIX-4040", "A", 130.0, 1 },
                    { 51, "", 6, "MIX-4041", "A", 110.0, 1 },
                    { 52, "", 6, "MIX-4042", "B", 195.0, 1 },
                    { 53, "", 6, "MIX-4045", "A", 150.0, 1 },
                    { 54, "", 6, "MIX-4046", "A", 160.0, 1 },
                    { 55, "", 6, "MIX-4050", "A", 170.0, 1 },
                    { 56, "", 6, "MIX-4070", "A", 115.0, 1 },
                    { 57, "", 7, "MPS-810MP", "N", 190.0, 1 },
                    { 58, "", 7, "MPS-802MP", "N", 200.0, 1 },
                    { 59, "", 7, "MPS-822MP", "N", 210.0, 1 },
                    { 60, "", 7, "BB-800", "N", 45.0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_InventoryId",
                table: "Carts",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
