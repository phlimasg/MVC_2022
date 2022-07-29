using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_2022.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "Insert into Categorias values ('Normal','Lanches com Ingredientes normais...')"
                );
            migrationBuilder.Sql(
                "Insert into Categorias values ('Veganos','Lanches com pra quem é fresco...')"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
