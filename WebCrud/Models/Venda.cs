using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Venda
    {
        [Required(ErrorMessage = "A data da venda é obrigatória.")]
        [Display(Name = "Data da venda")]
        public DateTime DataVen { get; set; }

        [Required(ErrorMessage = "O valor total da venda é obrigatório.")]
        [Display(Name = "Valor Total")]
        public decimal ValorVen { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        [Display(Name = "Forma de pagamento")]
        public string? FormaVen { get; set; }

        [Required(ErrorMessage = "A quantidade da venda é obrigatória.")]
        [Display(Name = "Quantidade da venda")]
        public int QuantVen { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        [Display(Name = "ID do Cliente")]
        public int Fkclienteid { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório.")]
        [Display(Name = "ID do Produto")]
        public int Fkprodutoid { get; set; }
    }
}