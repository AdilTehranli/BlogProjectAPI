﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DAL.Migrations
{
    public partial class CreatedBlogLikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 29, 18, 58, 24, 220, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 29, 18, 58, 24, 220, DateTimeKind.Utc).AddTicks(2748));

            migrationBuilder.CreateTable(
                name: "BlogLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reaction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogLikes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogLikes_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogLikes_AppUserId",
                table: "BlogLikes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogLikes_BlogId",
                table: "BlogLikes",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogLikes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 29, 18, 58, 24, 220, DateTimeKind.Utc).AddTicks(3684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 29, 18, 58, 24, 220, DateTimeKind.Utc).AddTicks(2748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
