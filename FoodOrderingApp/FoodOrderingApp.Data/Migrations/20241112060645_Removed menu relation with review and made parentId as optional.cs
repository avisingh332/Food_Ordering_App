using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedmenurelationwithreviewandmadeparentIdasoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Menus_DishId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DishId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "463338bd-5e4b-427d-aece-c0187e47dd4a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "8e3ddce3-7364-429e-b371-aee8df68b31b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "927eb077-b79a-4d64-8e15-d44b0bf3cf3c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "bbba5549-6df2-445f-bd59-e1d905e13a45" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "463338bd-5e4b-427d-aece-c0187e47dd4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3ddce3-7364-429e-b371-aee8df68b31b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927eb077-b79a-4d64-8e15-d44b0bf3cf3c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbba5549-6df2-445f-bd59-e1d905e13a45");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Reviews");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22c8d987-b45b-4ff5-acc1-e64f93ccc2f8", 0, "f1cc7e18-a72e-454b-9935-8d17f5e7d5a1", "customer1@test.com", false, "Customer 1", false, null, "CUSTOMER1@TEST.COM", "CUSTOMER1@TEST.COM", "AQAAAAIAAYagAAAAEF7Gg8QNN8d92JDSH0S20BTWCF4T5xpqcPQ+tTaSniRb2MG/kobG9Z7ARQ6BFKniBg==", null, false, "6aecff94-462d-48ca-817d-65e7cb0a1a26", false, "customer1@test.com" },
                    { "40ed6f16-690d-4c60-95f6-92dbf1f0e561", 0, "0522fab4-c9b5-4d67-82cf-73aff164515d", "customer2@test.com", false, "Customer 2", false, null, "CUSTOMER2@TEST.COM", "CUSTOMER2@TEST.COM", "AQAAAAIAAYagAAAAEOaFSMlChvXFDilnGCd9aV5mENPixIkmozSCwkxRT++ZzoQjndTk1hopAf5zt5eswA==", null, false, "8ac80ab3-a80b-48cb-9fdb-5001a27a3826", false, "customer2@test.com" },
                    { "d2cabf6f-bb8f-4793-9bcd-3f965dcd2f99", 0, "320225c6-4c77-4bb1-95e7-3beacd0ed745", "owner1@test.com", false, "Owner 1", false, null, "OWNER1@TEST.COM", "OWNER1@TEST.COM", "AQAAAAIAAYagAAAAEDXElIn1/tyCP739VgaGdd/YkYeBVg0Ya2lCA/y0R4nEUqGGb2irABk9XWjdNNePFw==", null, false, "5cfa66f6-8296-4a39-989e-8b43a2851112", false, "owner1@test.com" },
                    { "f9e35045-cf88-4909-a169-6b6dc51117f6", 0, "51619e87-32de-494d-8e31-2de668c83883", "owner2@test.com", false, "Owner 2", false, null, "OWNER2@TEST.COM", "OWNER2@TEST.COM", "AQAAAAIAAYagAAAAECtzFIwaEbQr5jxjwAhZxMM1msWELiP6n9+9Vo8d98m13bOf2UquXF/znMEekBVXPg==", null, false, "c7ead2f9-dbd3-4f6f-af82-9fa0f94c9512", false, "owner2@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "22c8d987-b45b-4ff5-acc1-e64f93ccc2f8" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "40ed6f16-690d-4c60-95f6-92dbf1f0e561" },
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "d2cabf6f-bb8f-4793-9bcd-3f965dcd2f99" },
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "f9e35045-cf88-4909-a169-6b6dc51117f6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MenuId",
                table: "Reviews",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Menus_MenuId",
                table: "Reviews",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Menus_MenuId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MenuId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "22c8d987-b45b-4ff5-acc1-e64f93ccc2f8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "40ed6f16-690d-4c60-95f6-92dbf1f0e561" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "d2cabf6f-bb8f-4793-9bcd-3f965dcd2f99" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "f9e35045-cf88-4909-a169-6b6dc51117f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c8d987-b45b-4ff5-acc1-e64f93ccc2f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40ed6f16-690d-4c60-95f6-92dbf1f0e561");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2cabf6f-bb8f-4793-9bcd-3f965dcd2f99");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9e35045-cf88-4909-a169-6b6dc51117f6");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Reviews");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DishId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "463338bd-5e4b-427d-aece-c0187e47dd4a", 0, "7874247c-9409-42af-8257-7a84a126c0cc", "owner1@test.com", false, "Owner 1", false, null, "OWNER1@TEST.COM", "OWNER1@TEST.COM", "AQAAAAIAAYagAAAAEADmjdfMIBKOnFz8QfSlf9PeRatKdCQwOB52RswzoVPUKvn+S0QfP3b1Z9u5iY1M+g==", null, false, "8e5f898f-3f27-4804-b0fd-3f742f3b798e", false, "owner1@test.com" },
                    { "8e3ddce3-7364-429e-b371-aee8df68b31b", 0, "c7cb16e9-c077-4c1c-b0e5-7ab049ed6674", "owner2@test.com", false, "Owner 2", false, null, "OWNER2@TEST.COM", "OWNER2@TEST.COM", "AQAAAAIAAYagAAAAEIzMThSyvJTambXWxI7fxVqtvBT4GyFcEu+WmnUwDsy1vDfsCxnSOFNSTULSAOQNiQ==", null, false, "e51a61a7-e3b9-464f-9715-189510b0fe69", false, "owner2@test.com" },
                    { "927eb077-b79a-4d64-8e15-d44b0bf3cf3c", 0, "6ade0067-d54b-4ac0-97f6-f4377befcd90", "customer2@test.com", false, "Customer 2", false, null, "CUSTOMER2@TEST.COM", "CUSTOMER2@TEST.COM", "AQAAAAIAAYagAAAAEDIi0v30RfFrsypMsrO1IGpSGTr8wU8Zj+pF5gTZXBZ19uz+c1kTEQ2WLWKIetpgCQ==", null, false, "48f1dbd9-7b69-4288-a7de-762743b22e51", false, "customer2@test.com" },
                    { "bbba5549-6df2-445f-bd59-e1d905e13a45", 0, "26c1fd83-9ef1-4636-b66b-10c0e92310e5", "customer1@test.com", false, "Customer 1", false, null, "CUSTOMER1@TEST.COM", "CUSTOMER1@TEST.COM", "AQAAAAIAAYagAAAAEFOjzUDhV4jRW5XVapSXqPmqqwNnF7FKA5S1cdmF0ncXyuzMxbQjVNLP/SMZeBR3Xg==", null, false, "db0589f4-9dcf-4e1b-8c80-b5a8a126db15", false, "customer1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "463338bd-5e4b-427d-aece-c0187e47dd4a" },
                    { "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a", "8e3ddce3-7364-429e-b371-aee8df68b31b" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "927eb077-b79a-4d64-8e15-d44b0bf3cf3c" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "bbba5549-6df2-445f-bd59-e1d905e13a45" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DishId",
                table: "Reviews",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Menus_DishId",
                table: "Reviews",
                column: "DishId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
