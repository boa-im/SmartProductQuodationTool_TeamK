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
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PVCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Qty = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "InventoryId", "Description", "Image", "Level", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, "Intelligent Fire Alarm Control Unit c/w 1 Intelligent Loop compatible with MGC Devices 4000 Series only)\r\n 	Expandable to three SLCs with the addition of the Dual Loop Controller ALC-480.\r\n 	1  20 Character  by 4 Line  Back-Lit LCD Display\r\n 	4  Class A/B (Style Z/Y) NAC Circuits\r\n 	Four Event Display Queues\r\n 	c/w UB-1024DS Universal Backbox & DOX-1024DSR RED Door\r\n 	Space for 2 RAX-1048TZDS LED Annunciator Modules\r\n* Standard RED Door", "https://mircom.com/wp-content/uploads/products/FX-401R-front_sm.jpg", 1, "FX-401R", "B", 3600.0, 1 },
                    { 2, "Intelligent Fire Alarm Control Unit c/w 1 Intelligent Loop compatible with MGC Devices 4000 Series only)\r\n 	Expandable to three SLCs with the addition of the Dual Loop Controller ALC-480.\r\n 	1  20 Character  by 4 Line  Back-Lit LCD Display\r\n 	4  Class A/B (Style Z/Y) NAC Circuits\r\n 	Four Event Display Queues\r\n 	c/w UB-1024DS Universal Backbox & DOX-1024DSR RED Door\r\n 	Space for 2 RAX-1048TZDS LED Annunciator Modules\r\n* Standard BLACK Door", "https://mircom.com/wp-content/uploads/products/FX-401-front_sm-1.jpg", 1, "FX-401B", "B", 3600.0, 1 },
                    { 3, "Remote LCD Annunciator, MIMIC Display for FX-400, FX-401, FX-3318, FX-3500 c/w Large 4 x 20 Character Back-Lit LCD Display, Four Event Display Queues. Common Controls, Mounts in BB-1000 Series Enclosure", "https://mircom.com/wp-content/uploads/products/RAX-LCD-LITE.png", 2, "RAX-LCD-LITE", "B", 1400.0, 1 },
                    { 4, "Main Annunciator Chassis  c/w 32 Bi-colored LEDs, 32 Zoned Trouble LEDs\r\nCommon Indicators --\r\nAC On, Common Trouble, Auxiliary Disconnect,\r\n2 Stage Acknowledge & General Alarm Activate (if Config.)\r\nCommon Controls --\r\nReset, Lamp Test,  Fire Drill, Auxiliary Disconnect, \r\nLocal Buzzer & Signal Silence. Mounts in BB-1000 Series Enclosure", "https://mircom.com/wp-content/uploads/products/RAM-1032TZDS_front.png", 2, "RAM-1032TZDS", "A", 825.0, 1 },
                    { 5, "Main Annunciator Chassis  c/w 32 Bi-colored LEDs, 32 Zoned Trouble LEDs\r\nCommon Indicators -- AC On, Common Trouble, Auxiliary Disconnect,\r\n2 Stage Acknowledge & General Alarm Activate (if Config.)\r\nCommon Controls -- Reset, Lamp Test,  Fire Drill, Auxiliary Disconnect, \r\nLocal Buzzer & Signal Silence\r\nMounts in BB-1000 Series enclosure or BB-5008 or BB-5014", "https://mircom.com/wp-content/uploads/products/RAM-1032TZDS-CC-1-1024x1018.png", 2, "RAM-1032TZDS-CC", "B", 1120.0, 1 },
                    { 6, "Adder Annunciator Chassis c/w 48 Bi-Coloured LEDs; 48 Zoned Trouble LED's\r\nMounts in BB-1000 Series enclosure", "https://mircom.com/wp-content/uploads/products/RAX-1048TZDS.png", 2, "RAX-1048TZDS", "A", 555.0, 1 },
                    { 7, "Conformal Coated Adder Annunciator Chassis c/w 48 Bi-Coloured LEDs; 48 Zoned Trouble LED's. Mounts in BB-1000 or BB-5000 Series Enclosure.", "https://mircom.com/wp-content/uploads/products/RAX-1048TZS-CC-1-1024x961.png", 2, "RAX-1048TZDS-CC", "B", 830.0, 1 },
                    { 8, "Interface for Configuring FleXNet™, FA-300 Series, FX-2000 Series, FX-401, FX-3500, QX-5000, UDACT-300, and MR-2300 Series", "https://mircom.com/wp-content/uploads/products/UIMA4.png", 3, "UIMA4", "A", 295.0, 1 },
                    { 9, "Fire Panel Configuration Kit4 With UIMA4", "", 3, "MGC-CONFIG-KIT4", "B", 425.0, 1 },
                    { 10, "FX-401 Dual Loop Controller Module 480 points (MGC Devices 4000 Series Compatible)", "", 4, "ALC-480", "B", 1160.0, 1 },
                    { 11, "Polarity Reversal & City Tie c/w Alarm, Supervisory & Trouble Transmit Capabilities", "https://mircom.com/wp-content/uploads/products/PR-300.png", 4, "PR-300", "B", 255.0, 1 },
                    { 12, "Adder Graphic Driver Board, c/w 48 Supervised Outputs, Output Connections via Terminals or Ribbon Cable\r\nMounts in Graphic Wall box", "https://mircom.com/wp-content/uploads/products/AGD-048-front.jpg", 4, "AGD-048", "B", 815.0, 1 },
                    { 13, "Master Graphic Driver Board c/w, Fire Alarm Common Control Switch Inputs & LED Outputs\r\n32 Supervised Outputs, Output Connections via Terminals or Ribbon Cable\r\nMounts in Graphic Wall box", "https://mircom.com/wp-content/uploads/products/MGD-32-front.jpg", 4, "MGD-32", "B", 1105.0, 1 },
                    { 14, "Power Supply Interface Board", "", 4, "PCS-100", "B", 210.0, 1 },
                    { 15, "Solenoid End of Line Resistor 47K, White Plate", "", 4, "MP-3500W", "B", 35.0, 1 },
                    { 16, "SMART Relay Module with Enclosure (12) RED", "https://mircom.com/wp-content/uploads/products/SRM-312R_right.jpg", 4, "SRM-312R", "C", 780.0, 1 },
                    { 17, "Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nRED Door & Black Backbox (12.75\"W X 9\"L X 1.85\"D without door)\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1001DR.png", 5, "BB-1001DR", "B", 285.0, 1 },
                    { 18, "Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nWHITE Door & Black Backbox (12.75\"W X 9\"L X 1.85\"D without door)\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1001D_White-1.png", 5, "BB-1001D", "A", 285.0, 1 },
                    { 19, "Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nBLACK Door & Black Backbox (12.75\"W X 9\"L X 1.85\"D without door)\r\nMounts over standard electrical box by others", "", 5, "BB-1001DB", "B", 285.0, 1 },
                    { 20, "NEW Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nStainless Steel Finish\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1001DS.png", 5, "BB-1001DS", "C", 490.0, 1 },
                    { 21, "Weather Protected Backbox for Series 1000 Annunciators (Houses 1 Module)\r\n 	Dimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n 	Rated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n 	Lexan sealed window, to protect against the challenges of an outdoor application\r\n 	Surface mount application. RED Door.\r\n 	NOTE: there is no need for thermostat or heater.  RAM-1032TZDS-CC must be ordered separately to match UL, ULC installation requirements", "https://mircom.com/wp-content/uploads/products/BB-1001_WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_approved_Weather_Protected_Fire_Label-1.png", 5, "BB-1001WPRA", "B", 1075.0, 1 },
                    { 22, "Weather Protected Backbox for Series 1000 Annunciators (Houses 1 Module)\r\n 	Dimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n 	Rated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n 	Lexan sealed window, to protect against the challenges of an outdoor application\r\n 	Surface mount application. WHITE Door.\r\n 	NOTE: there is no need for thermostat or heater.  RAM-1032TZDS-CC must be ordered separately to match UL, ULC installation requirements", "https://mircom.com/wp-content/uploads/products/BB-1001_WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_approved_Weather_Protected_Fire_Label-1.png", 5, "BB-1001WPA", "B", 1075.0, 1 },
                    { 23, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nRED Door & Black Backbox (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1002DS.png", 5, "BB-1002DR", "B", 515.0, 1 },
                    { 24, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nWHITE Door & Black Backbox (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1002D_White-1.png", 5, "BB-1002D", "B", 515.0, 1 },
                    { 25, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nBLACK Door & Black Backbox (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", "", 5, "BB-1002DB", "B", 515.0, 1 },
                    { 26, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nStainless Steel Finish (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1002DS-1.png", 5, "BB-1002DS", "C", 590.0, 1 },
                    { 27, "Weather Protected Backbox for Series 1000 Annunciators (Houses 2 Module)\r\n 	Dimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n 	Rated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n 	Lexan sealed window, to protect against the challenges of an outdoor application\r\n 	Surface mount application. RED Door.\r\n 	NOTE: there is no need for thermostat or heater. RAM-1032TZDS-CC and RAX-1048TZDS-CC must be ordered separately to match UL, ULC installation requirements.", "https://mircom.com/wp-content/uploads/products/BB-1002WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_label-1-1000x1000.png", 5, "BB-1002WPRA", "B", 1335.0, 1 },
                    { 28, "Weather Protected Backbox for Series 1000 Annunciators (Houses 2 Module)\r\n 	Dimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n 	Rated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n 	Lexan sealed window, to protect against the challenges of an outdoor application\r\n 	Surface mount application. WHITE Door.\r\n 	NOTE: there is no need for thermostat or heater. RAM-1032TZDS-CC and RAX-1048TZDS-CC must be ordered separately to match UL, ULC installation requirements.", "https://mircom.com/wp-content/uploads/products/BB-1002WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_label-1-1000x1000.png", 5, "BB-1002WPA", "C", 1335.0, 1 },
                    { 29, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nRED Door & Black Backbox (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1003D.png", 5, "BB-1003DR", "C", 640.0, 1 },
                    { 30, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nWHITE Door & Black Backbox (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1003D_White.png", 5, "BB-1003D", "B", 640.0, 1 },
                    { 31, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nBLACK Door & Black Backbox (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", "", 5, "BB-1003DB", "C", 640.0, 1 },
                    { 32, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nStainless Steel Finish (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", "https://mircom.com/wp-content/uploads/products/BB-1003DS.png", 5, "BB-1003DS", "C", 900.0, 1 },
                    { 33, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 8 Modules)\r\nRED  Door & Black Backbox (33”H x 22.5”W x 1.85”D)\r\nMounts over standard electrical box by others", "", 5, "BB-1008DR", "C", 1590.0, 1 },
                    { 34, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 8 Modules)\r\nWHITE  Door & Black Backbox (33”H x 22.5”W x 1.85”D)\r\nMounts over standard electrical box by others", "", 5, "BB-1008D", "B", 1590.0, 1 },
                    { 35, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 8 Modules)\r\nBLACK Door & Black Backbox (33”H x 22.5”W x 1.85”D)\r\nMounts over standard electrical box by others", "", 5, "BB-1008DB", "C", 1590.0, 1 },
                    { 36, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 12 Modules)\r\nRED Door & Black Backbox (45”H x 22.5”W x 1.85”D)\r\nMounts Over Standard Electrical Box by Others", "https://mircom.com/wp-content/uploads/2016/10/products-bb-1012-remote-enclosure.jpg", 5, "BB-1012DR", "C", 1770.0, 1 },
                    { 37, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 12 Modules)\r\nWHITE Door & Black Backbox (45”H x 22.5”W x 1.85”D)\r\nMounts Over Standard Electrical Box by Others", "", 5, "BB-1012D", "C", 1770.0, 1 },
                    { 38, "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 12 Modules)\r\nBLACK Door & Black Backbox (45”H x 22.5”W x 1.85”D)\r\nMounts Over Standard Electrical Box by Others", "", 5, "BB-1012DB", "C", 1770.0, 1 },
                    { 39, "4000 Series Photoelectric Detector W/O Isolation", "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg", 6, "MIX-4010", "A", 130.0, 1 },
                    { 40, "4000 Series Photoelectric Detector with Isolation", "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg", 6, "MIX-4010-ISO", "A", 140.0, 1 },
                    { 41, "4000 Series Multi Sensor - Photoelectric heat W/O Isolation", "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg", 6, "MIX-4020", "A", 160.0, 1 },
                    { 42, "4000 Series Multi Sensor - Photoelectric heat with Isolation", "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg", 6, "MIX-4020-ISO", "B", 170.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "Description", "Image", "Level", "Name", "PVCode", "Price", "Qty" },
                values: new object[,]
                {
                    { 43, "4000 Series Tri-Mode Heat Detector W/O Isolation", "https://mircom.com/wp-content/uploads/products/MIX-4030-tilt_lg.jpg", 6, "MIX-4030", "A", 110.0, 1 },
                    { 44, "4000 Series Tri-Mode Heat Detector with Isolation", "https://mircom.com/wp-content/uploads/products/MIX-4030-tilt_lg.jpg", 6, "MIX-4030-ISO", "A", 120.0, 1 },
                    { 45, "4000 Series 6\" Detector Base", "https://mircom.com/wp-content/uploads/products/bases-2-1.jpg", 6, "MIX-4001", "A", 28.0, 1 },
                    { 46, "4000 Series 4\" Detector Base", "https://mircom.com/wp-content/uploads/products/bases-2-1.jpg", 6, "MIX-4002", "A", 24.0, 1 },
                    { 47, "4000 Series Relay Base", "https://mircom.com/wp-content/uploads/products/MIX-4003-S-R-with-MIX-4020-ISO-1-scaled.jpg", 6, "MIX-4003-R", "B", 140.0, 1 },
                    { 48, "4000 Series Sounder Base", "https://mircom.com/wp-content/uploads/products/MIX-4003-S-R-with-MIX-4010-ISO-1.jpg", 6, "MIX-4003-S", "B", 1275.0, 1 },
                    { 49, "4000 Series Addressable Device Programmer", "https://mircom.com/wp-content/uploads/products/MIX-4090.png", 6, "MIX-4090", "A", 600.0, 1 },
                    { 50, "4000 Series Dual Input Module", "https://mircom.com/wp-content/uploads/products/MIX-4040.jpg", 6, "MIX-4040", "A", 130.0, 1 },
                    { 51, "4000 Series Mini Dual Input Module", "https://mircom.com/wp-content/uploads/products/MIX-4041-e1604012409118.jpg", 6, "MIX-4041", "A", 110.0, 1 },
                    { 52, "4000 Series Conventional Zone Module", "https://mircom.com/wp-content/uploads/products/MIX-4042.jpg", 6, "MIX-4042", "B", 195.0, 1 },
                    { 53, "4000 Series Dual Relay Module", "https://mircom.com/wp-content/uploads/products/MIX-4045.jpg", 6, "MIX-4045", "A", 150.0, 1 },
                    { 54, "4000 Series Supervised Output Module", "https://mircom.com/wp-content/uploads/products/MIX-4046.jpg", 6, "MIX-4046", "A", 160.0, 1 },
                    { 55, "Sync Module", "https://mircom.com/wp-content/uploads/products/MIX-4050.png", 6, "MIX-4050", "A", 170.0, 1 },
                    { 56, "4000 Series Isolator Module", "https://mircom.com/wp-content/uploads/products/MIX-4070.jpg", 6, "MIX-4070", "A", 115.0, 1 },
                    { 57, "MP 1 STAGE ADDR DOUBLE ACTION PULL STATION ULC", "https://mircom.com/wp-content/uploads/products/MPS-810.png", 7, "MPS-810MP", "N", 190.0, 1 },
                    { 58, "MP 2 STAGE ADDRESSABLE PULL STATION ULC", "", 7, "MPS-802MP", "N", 200.0, 1 },
                    { 59, "MP MAGLOCK 2 STAGE ADDR DOUBLE ACTION PULL STATION ULC", "", 7, "MPS-822MP", "N", 210.0, 1 },
                    { 60, "Surface Backbox For 800 Series Manual Station", "", 7, "BB-800", "N", 45.0, 1 }
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
