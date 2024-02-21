using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Clients_PlaceOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirth",
                table: "Clients",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceOfBirth",
                table: "Clients");
        }
    }
}
