using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Fornecedor
    {
        [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
        [Display(Name = "Nome do fornecedor")]
        public string? NomeFor { get; set; }

        [Required(ErrorMessage = "O endereco do fornecedor é obrigatório.")]
        [Display(Name = "Endereco do fornecedor")]
        public string? EnderecoFor { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [Display(Name = "Telefone do fornecedor")]
        public int TelefoneFor { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do Email é inválido.")]
        [Display(Name = "E-mail do fornecedor")]
        public string? EmailFor { get; set; }
    }
}
