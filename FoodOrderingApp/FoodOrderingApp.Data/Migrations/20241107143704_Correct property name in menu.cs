using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correctpropertynameinmenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RetaurantId",
                table: "Menus");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "03590656-cd6a-40c9-987f-da31638c5853" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "1089d0d1-d559-4706-9011-c7d148d5f4f9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "7bfbb923-0f8c-445f-9832-12f68c471df6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "815ee3d0-b444-4ee2-86a0-806c1611a282" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03590656-cd6a-40c9-987f-da31638c5853");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1089d0d1-d559-4706-9011-c7d148d5f4f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bfbb923-0f8c-445f-9832-12f68c471df6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "815ee3d0-b444-4ee2-86a0-806c1611a282");

            migrationBuilder.RenameColumn(
                name: "RetaurantId",
                table: "Menus",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RetaurantId",
                table: "Menus",
                newName: "IX_Menus_RestaurantId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "24087db8-c38a-480c-95e2-75ccca55d51e", 0, "de8d6b88-08ac-4bef-904c-56ea05ef4a6d", "customer2@test.com", false, "Customer 2", false, null, "CUSTOMER2@TEST.COM", "CUSTOMER2@TEST.COM", "AQAAAAIAAYagAAAAED4Sjn/vQUqk7dBLQ+Mnx/9tV+h98UVYp1FIewqbzYlkanu7cTv4wkb6acq8ZcFVaw==", null, false, "873b59e1-5add-4980-9ceb-e2a5aa1e63af", false, "customer2@test.com" },
                    { "3d27a098-de08-4f01-b29b-1cdbd6742821", 0, "06f13f1f-24b4-4d2f-90c5-a616ead4ed16", "owner2@test.com", false, "Owner 2", false, null, "OWNER2@TEST.COM", "OWNER2@TEST.COM", "AQAAAAIAAYagAAAAEJsDpNxqQNTdRM10FpQz3Rkc0YNzbmg6VNmf6jyKLuctGCHGt/rOmGAAM2fvY5ZiaQ==", null, false, "3870f522-e0ae-4a52-af24-ad4bfa777cd8", false, "owner2@test.com" },
                    { "475a0d75-881a-48c5-bfc3-791975cae21b", 0, "efe1c6be-e5f3-4bc8-8de7-aa5d02d1b6f2", "owner1@test.com", false, "Owner 1", false, null, "OWNER1@TEST.COM", "OWNER1@TEST.COM", "AQAAAAIAAYagAAAAEPW3xlhU6H6WAQQmyxjU4hiKr4rdIZBV4kRhKjWvz52aMR7dJgtWJpeWJMK+BWB0xg==", null, false, "9597e502-4d52-4995-9f7f-fa464ebe2176", false, "owner1@test.com" },
                    { "ce602941-075f-44a6-8baa-c2d4b56b677d", 0, "389de017-1b21-4012-85dc-92b7f3acb51b", "customer1@test.com", false, "Customer 1", false, null, "CUSTOMER1@TEST.COM", "CUSTOMER1@TEST.COM", "AQAAAAIAAYagAAAAEH+de3LJ33Of5p7y1YwCbmgK+v5eOD/ACUxZy+NuQBntUAt6xJXI1eBA3l87KuYnjQ==", null, false, "4f19ca68-c2bc-4a42-af4f-fb9cd5f434f3", false, "customer1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "24087db8-c38a-480c-95e2-75ccca55d51e" },
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "3d27a098-de08-4f01-b29b-1cdbd6742821" },
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "475a0d75-881a-48c5-bfc3-791975cae21b" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "ce602941-075f-44a6-8baa-c2d4b56b677d" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "24087db8-c38a-480c-95e2-75ccca55d51e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "3d27a098-de08-4f01-b29b-1cdbd6742821" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "475a0d75-881a-48c5-bfc3-791975cae21b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "ce602941-075f-44a6-8baa-c2d4b56b677d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24087db8-c38a-480c-95e2-75ccca55d51e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d27a098-de08-4f01-b29b-1cdbd6742821");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "475a0d75-881a-48c5-bfc3-791975cae21b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce602941-075f-44a6-8baa-c2d4b56b677d");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Menus",
                newName: "RetaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                newName: "IX_Menus_RetaurantId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03590656-cd6a-40c9-987f-da31638c5853", 0, "305637c8-95f3-4880-b2bb-a1c459d71d52", "owner2@test.com", false, "Owner 2", false, null, "OWNER2@TEST.COM", "OWNER2@TEST.COM", "AQAAAAIAAYagAAAAEEPgOOm1p52iFNo6qBtyW0Tyj/5ICqSwoDd9g6OCIWj/SnTDNtBbch5vNjyvjQk/qQ==", null, false, "14742f56-d6a5-4b3d-892c-96573d1b1809", false, "owner2@test.com" },
                    { "1089d0d1-d559-4706-9011-c7d148d5f4f9", 0, "9efca563-04ca-4613-b606-238547eaf7b0", "customer2@test.com", false, "Customer 2", false, null, "CUSTOMER2@TEST.COM", "CUSTOMER2@TEST.COM", "AQAAAAIAAYagAAAAEISUudpOqRJqRzpO7eeLQxq5mshHJhjR2Wj5tZkikBzZOd82Zflf1+Fc/5G87/N9vg==", null, false, "2488bb87-92e4-4b16-8e22-987aa1ffff89", false, "customer2@test.com" },
                    { "7bfbb923-0f8c-445f-9832-12f68c471df6", 0, "874e9a05-e396-46ef-bb3f-1d1871883e0b", "customer1@test.com", false, "Customer 1", false, null, "CUSTOMER1@TEST.COM", "CUSTOMER1@TEST.COM", "AQAAAAIAAYagAAAAEAkJTkdWBKVLGYd1AAb9OY7iJ+NTfOFu/Nb6LWvuWoukpjs6RYy2Aa715CxjfMesCQ==", null, false, "3023dcff-bcbe-482d-aa17-f0e139e01060", false, "customer1@test.com" },
                    { "815ee3d0-b444-4ee2-86a0-806c1611a282", 0, "d945bd11-ce48-4425-a89f-a4b827b40830", "owner1@test.com", false, "Owner 1", false, null, "OWNER1@TEST.COM", "OWNER1@TEST.COM", "AQAAAAIAAYagAAAAENnoXjmn4PfsHXqBBoI5n8UEJPfsG2zDpoZpwdMPPaZ+eM9uDq0EquWl1W+hG8bmpA==", null, false, "5c619e63-eeea-41a2-ad00-3d335e8e0f1b", false, "owner1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "03590656-cd6a-40c9-987f-da31638c5853" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "1089d0d1-d559-4706-9011-c7d148d5f4f9" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "7bfbb923-0f8c-445f-9832-12f68c471df6" },
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "815ee3d0-b444-4ee2-86a0-806c1611a282" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RetaurantId",
                table: "Menus",
                column: "RetaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
