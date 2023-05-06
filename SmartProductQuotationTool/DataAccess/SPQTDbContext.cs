using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SmartProductQuotationTool.Entities;

namespace SmartProductQuotationTool.DataAccess
{
    public class SPQTDbContext : IdentityDbContext<User>
    {
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Admin123#";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username, DiscountRate = 0 };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        public static User[] users =
        {
            new User() { UserName = "MTL-000001", Password = "Password1#", CompanyName = "Seneca College", PhoneNumber = "111-111-1111", Address1 = "1750 Finch Ave E", Address2 = "", City="North York", Province = "ON", Country = "Canada", PostalCode = "M2J 2X5", Website= "https://www.senecacollege.ca/home.html", DiscountRate=66.00 },
            new User() { UserName = "MTL-000002", Password = "Password2#", CompanyName = "Conestoga College", PhoneNumber = "222-222-2222", Address1 = "108 University Ave", Address2 = "", City = "Waterloo", Province = "ON", Country = "Canada", PostalCode = "N2J 2W2", Website = "https://www.conestogac.on.ca", DiscountRate = 68.00 },
            new User() { UserName = "MTL-000003", Password = "Password3#", CompanyName = "University of Waterloo", PhoneNumber = "333-333-3333", Address1 = "200 University Ave W", Address2 = "", City = "Waterloo", Province = "ON", Country = "Canada", PostalCode = "N2L 3G1", Website = "https://uwaterloo.ca", DiscountRate = 70.00 },
            new User() { UserName = "MTL-000004", Password = "Password4#", CompanyName = "University of Toronto", PhoneNumber = "444-444-4444", Address1 = "27 King's College Circle", Address2 = "", City = "Waterloo", Province = "ON", Country = "Canada", PostalCode = "M5S 1A1", Website = "https://www.utoronto.ca", DiscountRate = 72.00 }
        };

        public static async Task CreateUsers(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string roleName = "User";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add it to role
            foreach (User user in users) {
                if (await userManager.FindByNameAsync(user.UserName) == null)
                {
                    var result = await userManager.CreateAsync(user, user.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
        }

        public SPQTDbContext(DbContextOptions<SPQTDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class version of this to setup Identity tables:
            base.OnModelCreating(modelBuilder);

            // seeding Inventory:
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory() { InventoryId = 1, Level = 1, Name = "FX-401R", Description = "Intelligent Fire Alarm Control Unit c/w 1 Intelligent Loop compatible with MGC Devices 4000 Series only)\r\n \tExpandable to three SLCs with the addition of the Dual Loop Controller ALC-480.\r\n \t1  20 Character  by 4 Line  Back-Lit LCD Display\r\n \t4  Class A/B (Style Z/Y) NAC Circuits\r\n \tFour Event Display Queues\r\n \tc/w UB-1024DS Universal Backbox & DOX-1024DSR RED Door\r\n \tSpace for 2 RAX-1048TZDS LED Annunciator Modules\r\n* Standard RED Door", Price = 3600.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/FX-401R-front_sm.jpg" },
                new Inventory() { InventoryId = 2, Level = 1, Name = "FX-401B", Description = "Intelligent Fire Alarm Control Unit c/w 1 Intelligent Loop compatible with MGC Devices 4000 Series only)\r\n \tExpandable to three SLCs with the addition of the Dual Loop Controller ALC-480.\r\n \t1  20 Character  by 4 Line  Back-Lit LCD Display\r\n \t4  Class A/B (Style Z/Y) NAC Circuits\r\n \tFour Event Display Queues\r\n \tc/w UB-1024DS Universal Backbox & DOX-1024DSR RED Door\r\n \tSpace for 2 RAX-1048TZDS LED Annunciator Modules\r\n* Standard BLACK Door", Price = 3600.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/FX-401-front_sm-1.jpg" },
                new Inventory() { InventoryId = 3, Level = 2, Name = "RAX-LCD-LITE", Description = "Remote LCD Annunciator, MIMIC Display for FX-400, FX-401, FX-3318, FX-3500 c/w Large 4 x 20 Character Back-Lit LCD Display, Four Event Display Queues. Common Controls, Mounts in BB-1000 Series Enclosure", Price = 1400.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/RAX-LCD-LITE.png" },
                new Inventory() { InventoryId = 4, Level = 2, Name = "RAM-1032TZDS", Description = "Main Annunciator Chassis  c/w 32 Bi-colored LEDs, 32 Zoned Trouble LEDs\r\nCommon Indicators --\r\nAC On, Common Trouble, Auxiliary Disconnect,\r\n2 Stage Acknowledge & General Alarm Activate (if Config.)\r\nCommon Controls --\r\nReset, Lamp Test,  Fire Drill, Auxiliary Disconnect, \r\nLocal Buzzer & Signal Silence. Mounts in BB-1000 Series Enclosure", Price = 825.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/RAM-1032TZDS_front.png" },
                new Inventory() { InventoryId = 5, Level = 2, Name = "RAM-1032TZDS-CC", Description = "Main Annunciator Chassis  c/w 32 Bi-colored LEDs, 32 Zoned Trouble LEDs\r\nCommon Indicators -- AC On, Common Trouble, Auxiliary Disconnect,\r\n2 Stage Acknowledge & General Alarm Activate (if Config.)\r\nCommon Controls -- Reset, Lamp Test,  Fire Drill, Auxiliary Disconnect, \r\nLocal Buzzer & Signal Silence\r\nMounts in BB-1000 Series enclosure or BB-5008 or BB-5014", Price = 1120.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/RAM-1032TZDS-CC-1-1024x1018.png" },
                new Inventory() { InventoryId = 6, Level = 2, Name = "RAX-1048TZDS", Description = "Adder Annunciator Chassis c/w 48 Bi-Coloured LEDs; 48 Zoned Trouble LED's\r\nMounts in BB-1000 Series enclosure", Price = 555.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/RAX-1048TZDS.png" },
                new Inventory() { InventoryId = 7, Level = 2, Name = "RAX-1048TZDS-CC", Description = "Conformal Coated Adder Annunciator Chassis c/w 48 Bi-Coloured LEDs; 48 Zoned Trouble LED's. Mounts in BB-1000 or BB-5000 Series Enclosure.", Price = 830.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/RAX-1048TZS-CC-1-1024x961.png" },
                new Inventory() { InventoryId = 8, Level = 3, Name = "UIMA4", Description = "Interface for Configuring FleXNet™, FA-300 Series, FX-2000 Series, FX-401, FX-3500, QX-5000, UDACT-300, and MR-2300 Series", Price = 295.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/UIMA4.png" },
                new Inventory() { InventoryId = 9, Level = 3, Name = "MGC-CONFIG-KIT4", Description = "Fire Panel Configuration Kit4 With UIMA4", Price = 425.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 10, Level = 4, Name = "ALC-480", Description = "FX-401 Dual Loop Controller Module 480 points (MGC Devices 4000 Series Compatible)", Price = 1160.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 11, Level = 4, Name = "PR-300", Description = "Polarity Reversal & City Tie c/w Alarm, Supervisory & Trouble Transmit Capabilities", Price = 255.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/PR-300.png" },
                new Inventory() { InventoryId = 12, Level = 4, Name = "AGD-048", Description = "Adder Graphic Driver Board, c/w 48 Supervised Outputs, Output Connections via Terminals or Ribbon Cable\r\nMounts in Graphic Wall box", Price = 815.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/AGD-048-front.jpg" },
                new Inventory() { InventoryId = 13, Level = 4, Name = "MGD-32", Description = "Master Graphic Driver Board c/w, Fire Alarm Common Control Switch Inputs & LED Outputs\r\n32 Supervised Outputs, Output Connections via Terminals or Ribbon Cable\r\nMounts in Graphic Wall box", Price = 1105.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MGD-32-front.jpg" },
                new Inventory() { InventoryId = 14, Level = 4, Name = "PCS-100", Description = "Power Supply Interface Board", Price = 210.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 15, Level = 4, Name = "MP-3500W", Description = "Solenoid End of Line Resistor 47K, White Plate", Price = 35.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 16, Level = 4, Name = "SRM-312R", Description = "SMART Relay Module with Enclosure (12) RED", Price = 780.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/SRM-312R_right.jpg" },
                new Inventory() { InventoryId = 17, Level = 5, Name = "BB-1001DR", Description = "Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nRED Door & Black Backbox (12.75\"W X 9\"L X 1.85\"D without door)\r\nMounts over standard electrical box by others", Price = 285.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1001DR.png" },
                new Inventory() { InventoryId = 18, Level = 5, Name = "BB-1001D", Description = "Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nWHITE Door & Black Backbox (12.75\"W X 9\"L X 1.85\"D without door)\r\nMounts over standard electrical box by others", Price = 285.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1001D_White-1.png" },
                new Inventory() { InventoryId = 19, Level = 5, Name = "BB-1001DB", Description = "Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nBLACK Door & Black Backbox (12.75\"W X 9\"L X 1.85\"D without door)\r\nMounts over standard electrical box by others", Price = 285.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 20, Level = 5, Name = "BB-1001DS", Description = "NEW Semi-Flush Backbox for Series 1000 Annunciators (Houses 1 Module)\r\nStainless Steel Finish\r\nMounts over standard electrical box by others", Price = 490.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1001DS.png" },
                new Inventory() { InventoryId = 21, Level = 5, Name = "BB-1001WPRA", Description = "Weather Protected Backbox for Series 1000 Annunciators (Houses 1 Module)\r\n \tDimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n \tRated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n \tLexan sealed window, to protect against the challenges of an outdoor application\r\n \tSurface mount application. RED Door.\r\n \tNOTE: there is no need for thermostat or heater.  RAM-1032TZDS-CC must be ordered separately to match UL, ULC installation requirements", Price = 1075.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1001_WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_approved_Weather_Protected_Fire_Label-1.png" },
                new Inventory() { InventoryId = 22, Level = 5, Name = "BB-1001WPA", Description = "Weather Protected Backbox for Series 1000 Annunciators (Houses 1 Module)\r\n \tDimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n \tRated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n \tLexan sealed window, to protect against the challenges of an outdoor application\r\n \tSurface mount application. WHITE Door.\r\n \tNOTE: there is no need for thermostat or heater.  RAM-1032TZDS-CC must be ordered separately to match UL, ULC installation requirements", Price = 1075.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1001_WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_approved_Weather_Protected_Fire_Label-1.png" },
                new Inventory() { InventoryId = 23, Level = 5, Name = "BB-1002DR", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nRED Door & Black Backbox (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 515.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1002DS.png" },
                new Inventory() { InventoryId = 24, Level = 5, Name = "BB-1002D", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nWHITE Door & Black Backbox (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 515.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1002D_White-1.png" },
                new Inventory() { InventoryId = 25, Level = 5, Name = "BB-1002DB", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nBLACK Door & Black Backbox (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 515.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 26, Level = 5, Name = "BB-1002DS", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 2 Modules) \r\nStainless Steel Finish (18”H x 12.75”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 590.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1002DS-1.png" },
                new Inventory() { InventoryId = 27, Level = 5, Name = "BB-1002WPRA", Description = "Weather Protected Backbox for Series 1000 Annunciators (Houses 2 Module)\r\n \tDimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n \tRated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n \tLexan sealed window, to protect against the challenges of an outdoor application\r\n \tSurface mount application. RED Door.\r\n \tNOTE: there is no need for thermostat or heater. RAM-1032TZDS-CC and RAX-1048TZDS-CC must be ordered separately to match UL, ULC installation requirements.", Price = 1335.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1002WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_label-1-1000x1000.png" },
                new Inventory() { InventoryId = 28, Level = 5, Name = "BB-1002WPA", Description = "Weather Protected Backbox for Series 1000 Annunciators (Houses 2 Module)\r\n \tDimensions: (11-11/32\" Height, 13\" Width, 3.5\" Depth)\r\n \tRated for Outdoor Environment: +50°C to -40°C - 95% R.H. @60°C\r\n \tLexan sealed window, to protect against the challenges of an outdoor application\r\n \tSurface mount application. WHITE Door.\r\n \tNOTE: there is no need for thermostat or heater. RAM-1032TZDS-CC and RAX-1048TZDS-CC must be ordered separately to match UL, ULC installation requirements.", Price = 1335.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1002WPRA_Remote_Outdoor_Annunciator_Conformal_Coated_UL_ULC_label-1-1000x1000.png" },
                new Inventory() { InventoryId = 29, Level = 5, Name = "BB-1003DR", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nRED Door & Black Backbox (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", Price = 640.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1003D.png" },
                new Inventory() { InventoryId = 30, Level = 5, Name = "BB-1003D", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nWHITE Door & Black Backbox (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", Price = 640.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1003D_White.png" },
                new Inventory() { InventoryId = 31, Level = 5, Name = "BB-1003DB", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nBLACK Door & Black Backbox (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", Price = 640.00, PVCode = "C", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 32, Level = 5, Name = "BB-1003DS", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 3 Modules)\r\nStainless Steel Finish (12.75\"W X 26.4\"L X 1.85\"D) without door\r\nMounts over standard electrical box by others", Price = 900.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/BB-1003DS.png" },
                new Inventory() { InventoryId = 33, Level = 5, Name = "BB-1008DR", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 8 Modules)\r\nRED  Door & Black Backbox (33”H x 22.5”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 1590.00, PVCode = "C", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 34, Level = 5, Name = "BB-1008D", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 8 Modules)\r\nWHITE  Door & Black Backbox (33”H x 22.5”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 1590.00, PVCode = "B", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 35, Level = 5, Name = "BB-1008DB", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 8 Modules)\r\nBLACK Door & Black Backbox (33”H x 22.5”W x 1.85”D)\r\nMounts over standard electrical box by others", Price = 1590.00, PVCode = "C", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 36, Level = 5, Name = "BB-1012DR", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 12 Modules)\r\nRED Door & Black Backbox (45”H x 22.5”W x 1.85”D)\r\nMounts Over Standard Electrical Box by Others", Price = 1770.00, PVCode = "C", Qty = 1, Image = "https://mircom.com/wp-content/uploads/2016/10/products-bb-1012-remote-enclosure.jpg" },
                new Inventory() { InventoryId = 37, Level = 5, Name = "BB-1012D", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 12 Modules)\r\nWHITE Door & Black Backbox (45”H x 22.5”W x 1.85”D)\r\nMounts Over Standard Electrical Box by Others", Price = 1770.00, PVCode = "C", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 38, Level = 5, Name = "BB-1012DB", Description = "Semi-Flush Backbox for Series 1000 Annunciators  (Houses 12 Modules)\r\nBLACK Door & Black Backbox (45”H x 22.5”W x 1.85”D)\r\nMounts Over Standard Electrical Box by Others", Price = 1770.00, PVCode = "C", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 39, Level = 6, Name = "MIX-4010", Description = "4000 Series Photoelectric Detector W/O Isolation", Price = 130.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg" },
                new Inventory() { InventoryId = 40, Level = 6, Name = "MIX-4010-ISO", Description = "4000 Series Photoelectric Detector with Isolation", Price = 140.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg" },
                new Inventory() { InventoryId = 41, Level = 6, Name = "MIX-4020", Description = "4000 Series Multi Sensor - Photoelectric heat W/O Isolation", Price = 160.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg" },
                new Inventory() { InventoryId = 42, Level = 6, Name = "MIX-4020-ISO", Description = "4000 Series Multi Sensor - Photoelectric heat with Isolation", Price = 170.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4010-MIX-4020-tilt_lg.jpg" },
                new Inventory() { InventoryId = 43, Level = 6, Name = "MIX-4030", Description = "4000 Series Tri-Mode Heat Detector W/O Isolation", Price = 110.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4030-tilt_lg.jpg" },
                new Inventory() { InventoryId = 44, Level = 6, Name = "MIX-4030-ISO", Description = "4000 Series Tri-Mode Heat Detector with Isolation", Price = 120.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4030-tilt_lg.jpg" },
                new Inventory() { InventoryId = 45, Level = 6, Name = "MIX-4001", Description = "4000 Series 6\" Detector Base", Price = 28.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/bases-2-1.jpg" },
                new Inventory() { InventoryId = 46, Level = 6, Name = "MIX-4002", Description = "4000 Series 4\" Detector Base", Price = 24.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/bases-2-1.jpg" },
                new Inventory() { InventoryId = 47, Level = 6, Name = "MIX-4003-R", Description = "4000 Series Relay Base", Price = 140.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4003-S-R-with-MIX-4020-ISO-1-scaled.jpg" },
                new Inventory() { InventoryId = 48, Level = 6, Name = "MIX-4003-S", Description = "4000 Series Sounder Base", Price = 1275.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4003-S-R-with-MIX-4010-ISO-1.jpg" },
                new Inventory() { InventoryId = 49, Level = 6, Name = "MIX-4090", Description = "4000 Series Addressable Device Programmer", Price = 600.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4090.png" },
                new Inventory() { InventoryId = 50, Level = 6, Name = "MIX-4040", Description = "4000 Series Dual Input Module", Price = 130.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4040.jpg" },
                new Inventory() { InventoryId = 51, Level = 6, Name = "MIX-4041", Description = "4000 Series Mini Dual Input Module", Price = 110.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4041-e1604012409118.jpg" },
                new Inventory() { InventoryId = 52, Level = 6, Name = "MIX-4042", Description = "4000 Series Conventional Zone Module", Price = 195.00, PVCode = "B", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4042.jpg" },
                new Inventory() { InventoryId = 53, Level = 6, Name = "MIX-4045", Description = "4000 Series Dual Relay Module", Price = 150.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4045.jpg" },
                new Inventory() { InventoryId = 54, Level = 6, Name = "MIX-4046", Description = "4000 Series Supervised Output Module", Price = 160.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4046.jpg" },
                new Inventory() { InventoryId = 55, Level = 6, Name = "MIX-4050", Description = "Sync Module", Price = 170.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4050.png" },
                new Inventory() { InventoryId = 56, Level = 6, Name = "MIX-4070", Description = "4000 Series Isolator Module", Price = 115.00, PVCode = "A", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MIX-4070.jpg" },
                new Inventory() { InventoryId = 57, Level = 7, Name = "MPS-810MP", Description = "MP 1 STAGE ADDR DOUBLE ACTION PULL STATION ULC", Price = 190.00, PVCode = "N", Qty = 1, Image = "https://mircom.com/wp-content/uploads/products/MPS-810.png" },
                new Inventory() { InventoryId = 58, Level = 7, Name = "MPS-802MP", Description = "MP 2 STAGE ADDRESSABLE PULL STATION ULC", Price = 200.00, PVCode = "N", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 59, Level = 7, Name = "MPS-822MP", Description = "MP MAGLOCK 2 STAGE ADDR DOUBLE ACTION PULL STATION ULC", Price = 210.00, PVCode = "N", Qty = 1, Image = "" },
                new Inventory() { InventoryId = 60, Level = 7, Name = "BB-800", Description = "Surface Backbox For 800 Series Manual Station", Price = 45.00, PVCode = "N", Qty = 1, Image = "" }
            );
        }
    }
}
