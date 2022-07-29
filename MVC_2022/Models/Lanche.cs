using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_2022.Models
{
    [Table("lanches")]
    public class Lanche
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="O {0} é obrigatório!")]
        [Display(Name="Nome do lanche")]
        [StringLength(80, MinimumLength =10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Descrição do lanche")]        
        [MinLength(20, ErrorMessage = "Tamanho mínimo de {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Descrição detalhada do lanche")]        
        [MinLength(20, ErrorMessage = "Tamanho mínimo de {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Preço do lanche")]        
        [MinLength(1, ErrorMessage = "Tamanho mínimo de {1} caracteres.")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 99999999.99, ErrorMessage = "O valor deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho da imagem.")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres.")]
        public string ImgUrl { get; set; }

        [Display(Name = "Caminho da Thumbnail.")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres.")]
        public string ImgThumbnailUrl { get; set; }
        
        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Em estoque?")]
        public bool EmEstoque { get; set; }
        //[ForeignKey("id")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }


    }
}
