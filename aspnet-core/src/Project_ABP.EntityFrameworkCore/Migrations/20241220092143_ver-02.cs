using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ABP.Migrations
{
    /// <inheritdoc />
    public partial class ver02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Xas",
                table: "Xas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tinhs",
                table: "Tinhs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Huyens",
                table: "Huyens");

            migrationBuilder.RenameTable(
                name: "Xas",
                newName: "AppXa");

            migrationBuilder.RenameTable(
                name: "Tinhs",
                newName: "AppTinh");

            migrationBuilder.RenameTable(
                name: "Huyens",
                newName: "AppHuyen");

            migrationBuilder.AlterColumn<string>(
                name: "TenXa",
                table: "AppXa",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppXa",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Cap",
                table: "AppXa",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TenTinh",
                table: "AppTinh",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppTinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Cap",
                table: "AppTinh",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TenHuyen",
                table: "AppHuyen",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsDeleted",
                table: "AppHuyen",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Cap",
                table: "AppHuyen",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppXa",
                table: "AppXa",
                column: "MaXa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTinh",
                table: "AppTinh",
                column: "MaTinh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppHuyen",
                table: "AppHuyen",
                column: "MaHuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppXa",
                table: "AppXa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTinh",
                table: "AppTinh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppHuyen",
                table: "AppHuyen");

            migrationBuilder.RenameTable(
                name: "AppXa",
                newName: "Xas");

            migrationBuilder.RenameTable(
                name: "AppTinh",
                newName: "Tinhs");

            migrationBuilder.RenameTable(
                name: "AppHuyen",
                newName: "Huyens");

            migrationBuilder.AlterColumn<string>(
                name: "TenXa",
                table: "Xas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Xas",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Cap",
                table: "Xas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TenTinh",
                table: "Tinhs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tinhs",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Cap",
                table: "Tinhs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TenHuyen",
                table: "Huyens",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Huyens",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Cap",
                table: "Huyens",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Xas",
                table: "Xas",
                column: "MaXa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tinhs",
                table: "Tinhs",
                column: "MaTinh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Huyens",
                table: "Huyens",
                column: "MaHuyen");
        }
    }
}
