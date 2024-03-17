using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDriverPhelps.Migrations
{
    /// <inheritdoc />
    public partial class CriandoDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Maquina",
                table: "Maquina");

            migrationBuilder.RenameTable(
                name: "Maquina",
                newName: "AR");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AR",
                table: "AR",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AR",
                table: "AR");

            migrationBuilder.RenameTable(
                name: "AR",
                newName: "Maquina");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maquina",
                table: "Maquina",
                column: "Id");
        }
    }
}
