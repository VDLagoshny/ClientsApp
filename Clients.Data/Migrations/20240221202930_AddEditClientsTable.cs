using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEditClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Statuses_PersonStatusId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PersonStatusId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PersonStatusId",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StatusId",
                table: "Clients",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Statuses_StatusId",
                table: "Clients",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Statuses_StatusId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_StatusId",
                table: "Clients");

            migrationBuilder.AddColumn<long>(
                name: "PersonStatusId",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PersonStatusId",
                table: "Clients",
                column: "PersonStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Statuses_PersonStatusId",
                table: "Clients",
                column: "PersonStatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
