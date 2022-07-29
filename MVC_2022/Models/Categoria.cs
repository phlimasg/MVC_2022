using System.ComponentModel.DataAnnotations;

namespace MVC_2022.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="Campo obrigatório!")]
    [StringLength(100, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
    [Display(Name = "Informe o nome.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(100, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
    [Display(Name = "Informe a descrição do produto.")]
    public string Descricao { get; set; }
    public List<Lanche> Lanches { get; set; }
}
