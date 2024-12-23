using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ABP.Migrations
{
    /// <inheritdoc />
    public partial class ver09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppXa",
                table: "AppXa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppHuyen",
                table: "AppHuyen");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppXa",
                type: "bit",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "MaXa",
                table: "AppXa",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AppXa",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppHuyen",
                type: "bit",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "MaHuyen",
                table: "AppHuyen",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AppHuyen",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppXa",
                table: "AppXa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppHuyen",
                table: "AppHuyen",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppXa",
                table: "AppXa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppHuyen",
                table: "AppHuyen");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppHuyen");

            migrationBuilder.AlterColumn<int>(
                name: "MaXa",
                table: "AppXa",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppXa",
                type: "bit",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldDefaultValue: 0ul);

            migrationBuilder.AlterColumn<int>(
                name: "MaHuyen",
                table: "AppHuyen",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppHuyen",
                type: "bit",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldDefaultValue: 0ul);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppXa",
                table: "AppXa",
                column: "MaXa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppHuyen",
                table: "AppHuyen",
                column: "MaHuyen");
        }
    }
}
