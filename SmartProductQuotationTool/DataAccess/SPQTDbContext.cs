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
            string password = "admin";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        public SPQTDbContext(DbContextOptions<SPQTDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class version of this to setup Identity tables:
            base.OnModelCreating(modelBuilder);

            // seeding Inventory:
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory() { InventoryId = 1, Level = 1, Name = "FX-401R", Description = "", Price = 3600.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 2, Level = 1, Name = "FX-401B", Description = "", Price = 3600.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 3, Level = 2, Name = "RAX-LCD-LITE", Description = "", Price = 1400.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 4, Level = 2, Name = "RAM-1032TZDS", Description = "", Price = 825.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 5, Level = 2, Name = "RAM-1032TZDS-CC", Description = "", Price = 1120.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 6, Level = 2, Name = "RAX-1048TZDS", Description = "", Price = 555.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 7, Level = 2, Name = "RAX-1048TZDS-CC", Description = "", Price = 830.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 8, Level = 3, Name = "UIMA4", Description = "", Price = 295.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 9, Level = 3, Name = "MGC-CONFIG-KIT4", Description = "", Price = 425.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 10, Level = 4, Name = "ALC-480", Description = "", Price = 1160.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 11, Level = 4, Name = "PR-300", Description = "", Price = 255.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 12, Level = 4, Name = "AGD-048", Description = "", Price = 815.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 13, Level = 4, Name = "MGD-32", Description = "", Price = 1105.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 14, Level = 4, Name = "PCS-100", Description = "", Price = 210.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 15, Level = 4, Name = "MP-3500W", Description = "", Price = 35.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 16, Level = 4, Name = "SRM-312R", Description = "", Price = 780.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 17, Level = 5, Name = "BB-1001DR", Description = "", Price = 285.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 18, Level = 5, Name = "BB-1001D", Description = "", Price = 285.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 19, Level = 5, Name = "BB-1001DB", Description = "", Price = 285.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 20, Level = 5, Name = "BB-1001DS", Description = "", Price = 490.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 21, Level = 5, Name = "BB-1001WPRA", Description = "", Price = 1075.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 22, Level = 5, Name = "BB-1001WPA", Description = "", Price = 1075.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 23, Level = 5, Name = "BB-1002DR", Description = "", Price = 515.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 24, Level = 5, Name = "BB-1002D", Description = "", Price = 515.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 25, Level = 5, Name = "BB-1002DB", Description = "", Price = 515.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 26, Level = 5, Name = "BB-1002DS", Description = "", Price = 590.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 27, Level = 5, Name = "BB-1002WPRA", Description = "", Price = 1335.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 28, Level = 5, Name = "BB-1002WPA", Description = "", Price = 1335.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 29, Level = 5, Name = "BB-1003DR", Description = "", Price = 640.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 30, Level = 5, Name = "BB-1003D", Description = "", Price = 640.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 31, Level = 5, Name = "BB-1003DB", Description = "", Price = 640.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 32, Level = 5, Name = "BB-1003DS", Description = "", Price = 900.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 33, Level = 5, Name = "BB-1008DR", Description = "", Price = 1590.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 34, Level = 5, Name = "BB-1008D", Description = "", Price = 1590.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 35, Level = 5, Name = "BB-1008DB", Description = "", Price = 1590.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 36, Level = 5, Name = "BB-1012DR", Description = "", Price = 1770.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 37, Level = 5, Name = "BB-1012D", Description = "", Price = 1770.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 38, Level = 5, Name = "BB-1012DB", Description = "", Price = 1770.00, PVCode = "C", Qty = 1 },
                new Inventory() { InventoryId = 39, Level = 6, Name = "MIX-4010", Description = "", Price = 130.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 40, Level = 6, Name = "MIX-4010-ISO", Description = "", Price = 140.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 41, Level = 6, Name = "MIX-4020", Description = "", Price = 160.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 42, Level = 6, Name = "MIX-4020-ISO", Description = "", Price = 170.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 43, Level = 6, Name = "MIX-4030", Description = "", Price = 110.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 44, Level = 6, Name = "MIX-4030-ISO", Description = "", Price = 120.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 45, Level = 6, Name = "MIX-4001", Description = "", Price = 28.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 46, Level = 6, Name = "MIX-4002", Description = "", Price = 24.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 47, Level = 6, Name = "MIX-4003-R", Description = "", Price = 140.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 48, Level = 6, Name = "MIX-4003-S", Description = "", Price = 1275.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 49, Level = 6, Name = "MIX-4090", Description = "", Price = 600.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 50, Level = 6, Name = "MIX-4040", Description = "", Price = 130.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 51, Level = 6, Name = "MIX-4041", Description = "", Price = 110.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 52, Level = 6, Name = "MIX-4042", Description = "", Price = 195.00, PVCode = "B", Qty = 1 },
                new Inventory() { InventoryId = 53, Level = 6, Name = "MIX-4045", Description = "", Price = 150.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 54, Level = 6, Name = "MIX-4046", Description = "", Price = 160.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 55, Level = 6, Name = "MIX-4050", Description = "", Price = 170.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 56, Level = 6, Name = "MIX-4070", Description = "", Price = 115.00, PVCode = "A", Qty = 1 },
                new Inventory() { InventoryId = 57, Level = 7, Name = "MPS-810MP", Description = "", Price = 190.00, PVCode = "N", Qty = 1 },
                new Inventory() { InventoryId = 58, Level = 7, Name = "MPS-802MP", Description = "", Price = 200.00, PVCode = "N", Qty = 1 },
                new Inventory() { InventoryId = 59, Level = 7, Name = "MPS-822MP", Description = "", Price = 210.00, PVCode = "N", Qty = 1 },
                new Inventory() { InventoryId = 60, Level = 7, Name = "BB-800", Description = "", Price = 45.00, PVCode = "N", Qty = 1 }
            );
            
            modelBuilder.Entity<User>().HasData(
                new User() { UserName = "MTL-000001", Password = "password1", CompanyName = "Seneca College", PhoneNumber = "111-111-1111", Address1 = "1750 Finch Ave E", Address2 = "", City="North York", Province = "ON", Country = "Canada", PostalCode = "M2J 2X5", Website= "https://www.senecacollege.ca/home.html", Discount=66.00 },
                new User() { UserName = "MTL-000002", Password = "password2", CompanyName = "Conestoga College", PhoneNumber = "222-222-2222", Address1 = "108 University Ave", Address2 = "", City = "Waterloo", Province = "ON", Country = "Canada", PostalCode = "N2J 2W2", Website = "https://www.conestogac.on.ca", Discount = 68.00 },
                new User() { UserName = "MTL-000003", Password = "password3", CompanyName = "University of Waterloo", PhoneNumber = "333-333-3333", Address1 = "200 University Ave W", Address2 = "", City = "Waterloo", Province = "ON", Country = "Canada", PostalCode = "N2L 3G1", Website = "https://uwaterloo.ca", Discount = 70.00 },
                new User() { UserName = "MTL-000004", Password = "password4", CompanyName = "University of Toronto", PhoneNumber = "444-444-4444", Address1 = "27 King's College Circle", Address2 = "", City = "Waterloo", Province = "ON", Country = "Canada", PostalCode = "M5S 1A1", Website = "https://www.utoronto.ca", Discount = 72.00 }
            );
        }
    }
}
