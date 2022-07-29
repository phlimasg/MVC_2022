using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_2022.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*,[Nome]
              ,[DescricaoCurta]
              ,[DescricaoDetalhada]
              ,[Preco]
              ,[ImgUrl]
              ,[ImgThumbnailUrl]
              ,[IsLanchePreferido]
              ,[EmEstoque]
              ,[CategoriaId]*/
            migrationBuilder.Sql(
                "Insert into Lanches values ('Hamburguer','Vulgo podrão...'," +
                "'O melhor e mais barato podrão da cidade',2.50,'cheesesalada1.jpg','cheesesalada1.jpg',1,1,1)"
                );
            migrationBuilder.Sql(
                "Insert into Lanches values ('Hamburguer 2','Vulgo podrão com 2 carnes.'," +
                "'O melhor e mais barato podrão com 2 carnes da cidade',3.50,'cheesesalada2.jpg','cheesesalada2.jpg',1,1,1)"
                );
            migrationBuilder.Sql(
                "Insert into Lanches values ('Vegano 1','Hamburguer de mentira.'," +
                "'Tem gosto de nada saporra e é caro.',15.50,'cheesesalada3.jpg','cheesesalada3.jpg',1,1,2)"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from lanches");
        }
    }
}
