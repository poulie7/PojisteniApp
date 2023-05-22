using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PojisteniApp.Data.Migrations
{
    public partial class addedProprtiesPojistenec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Pojistenec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pojistenec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Pojistenec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PSC",
                table: "Pojistenec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Pojistenec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Pojistenec");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pojistenec");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Pojistenec");

            migrationBuilder.DropColumn(
                name: "PSC",
                table: "Pojistenec");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Pojistenec");
        }
    }
}
