using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Material
    {
        [Required(ErrorMessage = "O nome do material é obrigatório.")]
        [Display(Name = "Nome do material")]
        public string? NomeMat { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [Display(Name = "Quantidade em estoque")]
        public int QuantMat { get; set; }

        [Required(ErrorMessage = "A validade do produto é obrigatória.")]
        [Display(Name = "Validade do material")]
        public DateTime ValiMat { get; set; }

        [Required(ErrorMessage = "O fornecedor é obrigatório.")]
        [Display(Name = "ID do Fornecedor")]
        public int Fkfornecedorid { get; set; }
    }
}
