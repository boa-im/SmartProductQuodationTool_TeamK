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
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "Address2", "City", "CompanyName", "ConcurrencyStamp", "Country", "Discount", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "TwoFactorEnabled", "UserName", "Website" },
                values: new object[,]
                {
                    { "2c2fd1f2-8d63-4f87-8efe-5829ae28358b", 0, "27 King's College Circle", "", "Waterloo", "University of Toronto", "010f56ed-52df-4189-a70f-d2054a081d82", "Canada", 72.0, null, false, false, null, null, null, "password4", null, "444-444-4444", false, "M5S 1A1", "ON", "5416e4c6-577e-481f-8264-3bdd07209235", false, "MTL-000004", "https://www.utoronto.ca" },
                    { "630bc74e-7c74-4758-b966-86660ee4c396", 0, "200 University Ave W", "", "Waterloo", "University of Waterloo", "e7e63c27-9ea1-4f96-936a-0a3ce7280b37", "Canada", 70.0, null, false, false, null, null, null, "password3", null, "333-333-3333", false, "N2L 3G1", "ON", "55b3d340-f1d1-4a06-9046-0f5ed6eba65d", false, "MTL-000003", "https://uwaterloo.ca" },
                    { "866ee683-3922-424e-9d72-8c5ea0c323fb", 0, "1750 Finch Ave E", "", "North York", "Seneca College", "38773522-0928-4e3d-884e-fb7c67251b13", "Canada", 66.0, null, false, false, null, null, null, "password1", null, "111-111-1111", false, "M2J 2X5", "ON", "21c92710-53d1-41bb-94a5-f06e7004825d", false, "MTL-000001", "https://www.senecacollege.ca/home.html" },
                    { "91ebd211-ac62-43ee-9c91-fa27bd46e12b", 0, "108 University Ave", "", "Waterloo", "Conestoga College", "19574602-41a8-4652-9cc5-ad1ba2a9cae2", "Canada", 68.0, null, false, false, null, null, null, "password2", null, "222-222-2222", false, "N2J 2W2", "ON", "e5a629e0-008f-4b52-a62a-f8aedb7835b0", false, "MTL-000002", "https://www.conestogac.on.ca" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "CartId", "Description", "Level", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, null, "", 1, "FX-401R", "B", 3600.0, 1 },
                    { 2, null, "", 1, "FX-401B", "B", 3600.0, 1 },
                    { 3, null, "", 2, "RAX-LCD-LITE", "B", 1400.0, 1 },
                    { 4, null, "", 2, "RAM-1032TZDS", "A", 825.0, 1 },
                    { 5, null, "", 2, "RAM-1032TZDS-CC", "B", 1120.0, 1 },
                    { 6, null, "", 2, "RAX-1048TZDS", "A", 555.0, 1 },
                    { 7, null, "", 2, "RAX-1048TZDS-CC", "B", 830.0, 1 },
                    { 8, null, "", 3, "UIMA4", "A", 295.0, 1 },
                    { 9, null, "", 3, "MGC-CONFIG-KIT4", "B", 425.0, 1 },
                    { 10, null, "", 4, "ALC-480", "B", 1160.0, 1 },
                    { 11, null, "", 4, "PR-300", "B", 255.0, 1 },
                    { 12, null, "", 4, "AGD-048", "B", 815.0, 1 },
                    { 13, null, "", 4, "MGD-32", "B", 1105.0, 1 },
                    { 14, null, "", 4, "PCS-100", "B", 210.0, 1 },
                    { 15, null, "", 4, "MP-3500W", "B", 35.0, 1 },
                    { 16, null, "", 4, "SRM-312R", "C", 780.0, 1 },
                    { 17, null, "", 5, "BB-1001DR", "B", 285.0, 1 },
                    { 18, null, "", 5, "BB-1001D", "A", 285.0, 1 },
                    { 19, null, "", 5, "BB-1001DB", "B", 285.0, 1 },
                    { 20, null, "", 5, "BB-1001DS", "C", 490.0, 1 },
                    { 21, null, "", 5, "BB-1001WPRA", "B", 1075.0, 1 },
                    { 22, null, "", 5, "BB-1001WPA", "B", 1075.0, 1 },
                    { 23, null, "", 5, "BB-1002DR", "B", 515.0, 1 },
                    { 24, null, "", 5, "BB-1002D", "B", 515.0, 1 },
                    { 25, null, "", 5, "BB-1002DB", "B", 515.0, 1 },
                    { 26, null, "", 5, "BB-1002DS", "C", 590.0, 1 },
                    { 27, null, "", 5, "BB-1002WPRA", "B", 1335.0, 1 },
                    { 28, null, "", 5, "BB-1002WPA", "C", 1335.0, 1 },
                    { 29, null, "", 5, "BB-1003DR", "C", 640.0, 1 },
                    { 30, null, "", 5, "BB-1003D", "B", 640.0, 1 },
                    { 31, null, "", 5, "BB-1003DB", "C", 640.0, 1 },
                    { 32, null, "", 5, "BB-1003DS", "C", 900.0, 1 },
                    { 33, null, "", 5, "BB-1008DR", "C", 1590.0, 1 },
                    { 34, null, "", 5, "BB-1008D", "B", 1590.0, 1 },
                    { 35, null, "", 5, "BB-1008DB", "C", 1590.0, 1 },
                    { 36, null, "", 5, "BB-1012DR", "C", 1770.0, 1 },
                    { 37, null, "", 5, "BB-1012D", "C", 1770.0, 1 },
                    { 38, null, "", 5, "BB-1012DB", "C", 1770.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "CartId", "Description", "Level", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 39, null, "", 6, "MIX-4010", "A", 130.0, 1 },
                    { 40, null, "", 6, "MIX-4010-ISO", "A", 140.0, 1 },
                    { 41, null, "", 6, "MIX-4020", "A", 160.0, 1 },
                    { 42, null, "", 6, "MIX-4020-ISO", "B", 170.0, 1 },
                    { 43, null, "", 6, "MIX-4030", "A", 110.0, 1 },
                    { 44, null, "", 6, "MIX-4030-ISO", "A", 120.0, 1 },
                    { 45, null, "", 6, "MIX-4001", "A", 28.0, 1 },
                    { 46, null, "", 6, "MIX-4002", "A", 24.0, 1 },
                    { 47, null, "", 6, "MIX-4003-R", "B", 140.0, 1 },
                    { 48, null, "", 6, "MIX-4003-S", "B", 1275.0, 1 },
                    { 49, null, "", 6, "MIX-4090", "A", 600.0, 1 },
                    { 50, null, "", 6, "MIX-4040", "A", 130.0, 1 },
                    { 51, null, "", 6, "MIX-4041", "A", 110.0, 1 },
                    { 52, null, "", 6, "MIX-4042", "B", 195.0, 1 },
                    { 53, null, "", 6, "MIX-4045", "A", 150.0, 1 },
                    { 54, null, "", 6, "MIX-4046", "A", 160.0, 1 },
                    { 55, null, "", 6, "MIX-4050", "A", 170.0, 1 },
                    { 56, null, "", 6, "MIX-4070", "A", 115.0, 1 },
                    { 57, null, "", 7, "MPS-810MP", "N", 190.0, 1 },
                    { 58, null, "", 7, "MPS-802MP", "N", 200.0, 1 },
                    { 59, null, "", 7, "MPS-822MP", "N", 210.0, 1 },
                    { 60, null, "", 7, "BB-800", "N", 45.0, 1 }
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
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
