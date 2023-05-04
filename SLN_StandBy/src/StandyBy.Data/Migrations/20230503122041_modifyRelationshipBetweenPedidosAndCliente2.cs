using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandyBy.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyRelationshipBetweenPedidosAndCliente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                unique: true);
        }
    }
}
