using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ABP.Migrations
{
    /// <inheritdoc />
    public partial class ver05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTinh",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppTinh");

            migrationBuilder.AlterColumn<int>(
                name: "MaTinh",
                table: "AppTinh",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AppTinh",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTinh",
                table: "AppTinh",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTinh",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppTinh");

            migrationBuilder.AlterColumn<int>(
                name: "MaTinh",
                table: "AppTinh",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTinh",
                table: "AppTinh",
                column: "MaTinh");
        }
    }
}
