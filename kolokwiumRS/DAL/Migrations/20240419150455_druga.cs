using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class druga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historie_Groupy_GrupaID",
                table: "Historie");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenci_Groupy_GrupaID",
                table: "Studenci");

            migrationBuilder.DropIndex(
                name: "IX_Studenci_GrupaID",
                table: "Studenci");

            migrationBuilder.DropIndex(
                name: "IX_Historie_GrupaID",
                table: "Historie");

            migrationBuilder.DropColumn(
                name: "GrupaID",
                table: "Studenci");

            migrationBuilder.DropColumn(
                name: "GrupaID",
                table: "Historie");

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GroupaID",
                table: "Studenci",
                column: "GroupaID");

            migrationBuilder.CreateIndex(
                name: "IX_Historie_GroupID",
                table: "Historie",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Historie_Groupy_GroupID",
                table: "Historie",
                column: "GroupID",
                principalTable: "Groupy",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenci_Groupy_GroupaID",
                table: "Studenci",
                column: "GroupaID",
                principalTable: "Groupy",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historie_Groupy_GroupID",
                table: "Historie");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenci_Groupy_GroupaID",
                table: "Studenci");

            migrationBuilder.DropIndex(
                name: "IX_Studenci_GroupaID",
                table: "Studenci");

            migrationBuilder.DropIndex(
                name: "IX_Historie_GroupID",
                table: "Historie");

            migrationBuilder.AddColumn<int>(
                name: "GrupaID",
                table: "Studenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrupaID",
                table: "Historie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GrupaID",
                table: "Studenci",
                column: "GrupaID");

            migrationBuilder.CreateIndex(
                name: "IX_Historie_GrupaID",
                table: "Historie",
                column: "GrupaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Historie_Groupy_GrupaID",
                table: "Historie",
                column: "GrupaID",
                principalTable: "Groupy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenci_Groupy_GrupaID",
                table: "Studenci",
                column: "GrupaID",
                principalTable: "Groupy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
