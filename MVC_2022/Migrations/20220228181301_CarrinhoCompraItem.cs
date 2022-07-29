using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_2022.Migrations
{
    public partial class CarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItems",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    lancheid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItems_lanches_lancheid",
                        column: x => x.lancheid,
                        principalTable: "lanches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItems_lancheid",
                table: "CarrinhoCompraItems",
                column: "lancheid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItems");
        }
    }
}
