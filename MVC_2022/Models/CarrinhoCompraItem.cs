using System.ComponentModel.DataAnnotations;

namespace MVC_2022.Models
{
    public class CarrinhoCompraItem
    {
        public string id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public int Quantidade { get; set; }
        
        
        [StringLength(200)]
        public string CarrinhoCompraid { get; set; }        
        public Lanche Lanche { get; set; }

    }
}
