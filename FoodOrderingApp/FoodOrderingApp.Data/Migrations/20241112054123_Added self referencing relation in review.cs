using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addedselfreferencingrelationinreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
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
                name: "IX_Reviews_ParentId",
                table: "Reviews",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviews_ParentId",
                table: "Reviews",
                column: "ParentId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviews_ParentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ParentId",
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
                name: "ParentId",
                table: "Reviews");

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
        }
    }
}
