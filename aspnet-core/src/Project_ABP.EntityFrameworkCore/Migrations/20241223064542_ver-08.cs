using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ABP.Migrations
{
    /// <inheritdoc />
    public partial class ver08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppTinh");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppTinh",
                type: "bit",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppTinh",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppTinh",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppTinh");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppTinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldDefaultValue: 0ul);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppTinh",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppTinh",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
