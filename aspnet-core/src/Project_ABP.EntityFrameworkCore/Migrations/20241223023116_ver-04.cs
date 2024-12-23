using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ABP.Migrations
{
    /// <inheritdoc />
    public partial class ver04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppXa",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppXa",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppXa",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppXa",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppXa",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppXa",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppTinh",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppTinh",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppTinh",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppTinh",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppHuyen",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppHuyen",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppHuyen",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppHuyen",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppHuyen",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppHuyen",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppXa");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppTinh");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppHuyen");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppHuyen");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppHuyen");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppHuyen");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppHuyen");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppHuyen");
        }
    }
}
