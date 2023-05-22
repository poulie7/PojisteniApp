using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PojisteniApp.Data.Migrations
{
    public partial class conn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnId",
                table: "Pojisteni",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnId",
                table: "Pojistenec",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PojistenecId = table.Column<int>(type: "int", nullable: false),
                    PojisteniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conn", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pojisteni_ConnId",
                table: "Pojisteni",
                column: "ConnId");

            migrationBuilder.CreateIndex(
                name: "IX_Pojistenec_ConnId",
                table: "Pojistenec",
                column: "ConnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pojistenec_Conn_ConnId",
                table: "Pojistenec",
                column: "ConnId",
                principalTable: "Conn",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pojisteni_Conn_ConnId",
                table: "Pojisteni",
                column: "ConnId",
                principalTable: "Conn",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pojistenec_Conn_ConnId",
                table: "Pojistenec");

            migrationBuilder.DropForeignKey(
                name: "FK_Pojisteni_Conn_ConnId",
                table: "Pojisteni");

            migrationBuilder.DropTable(
                name: "Conn");

            migrationBuilder.DropIndex(
                name: "IX_Pojisteni_ConnId",
                table: "Pojisteni");

            migrationBuilder.DropIndex(
                name: "IX_Pojistenec_ConnId",
                table: "Pojistenec");

            migrationBuilder.DropColumn(
                name: "ConnId",
                table: "Pojisteni");

            migrationBuilder.DropColumn(
                name: "ConnId",
                table: "Pojistenec");
        }
    }
}
