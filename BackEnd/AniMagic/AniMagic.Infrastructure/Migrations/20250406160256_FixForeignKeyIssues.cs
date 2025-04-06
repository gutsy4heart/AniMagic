using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AniMagic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cartoons_CartoonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cartoons_CartoonId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Cartoons_CartoonId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Cartoons_CartoonId1",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CartoonId1",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CartoonId1",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2b018b92-25d8-4593-bf3a-d39fd59773be"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("52481864-9085-4df7-adb7-aa006e8fd368"));

            migrationBuilder.DropColumn(
                name: "CartoonId1",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CartoonId1",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Cartoon",
                table: "Comments",
                column: "CartoonId",
                principalTable: "Cartoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Cartoon",
                table: "Ratings",
                column: "CartoonId",
                principalTable: "Cartoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Cartoon",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Cartoon",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.AddColumn<Guid>(
                name: "CartoonId1",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CartoonId1",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                columns: new[] { "UserId", "CartoonId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b018b92-25d8-4593-bf3a-d39fd59773be"), "Admin" },
                    { new Guid("52481864-9085-4df7-adb7-aa006e8fd368"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CartoonId1",
                table: "Ratings",
                column: "CartoonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CartoonId1",
                table: "Comments",
                column: "CartoonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cartoons_CartoonId",
                table: "Comments",
                column: "CartoonId",
                principalTable: "Cartoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cartoons_CartoonId1",
                table: "Comments",
                column: "CartoonId1",
                principalTable: "Cartoons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Cartoons_CartoonId",
                table: "Ratings",
                column: "CartoonId",
                principalTable: "Cartoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Cartoons_CartoonId1",
                table: "Ratings",
                column: "CartoonId1",
                principalTable: "Cartoons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
