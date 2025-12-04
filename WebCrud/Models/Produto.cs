using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Produto
    {
 
        [Required(ErrorMessage = "O Nome do Produto é obrigatório.")]
        [Display(Name = "Nome do Produto")]
        public string? Prodnome { get; set; }

        [Required(ErrorMessage = "A Quantidade em Estoque é obrigatória.")]
        [Display(Name = "Quantidade em Estoque")]
        public int Quant_estoque { get; set; }

        [Required(ErrorMessage = "O Valor Unitário é obrigatório.")]
        [Display(Name = "Valor Unitário")]
        public decimal Valor_unitario { get; set; } 

        [Required(ErrorMessage = "O Valor por Metro é obrigatório.")]
        [Display(Name = "Valor por Metro")]
        public decimal Valor_metro { get; set; } 

        [Required(ErrorMessage = "A Especificação/Descrição é obrigatória.")]
        [Display(Name = "Especificação/Descrição")]
        public string? Proddescr { get; set; }
    }
}