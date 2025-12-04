using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "O salário do funcíonário é obrigatório.")]
        [Display(Name = "Salário do funcionário")]
        public decimal Salariofun { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [Display(Name = "Nome do funcionário")]
        public string? Nomefun { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [Display(Name = "Endereco do funcionário")]
        public string? Enderecofun { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [Display(Name = "Telefone do funcionário")]
        public string? Telefonefun { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do Email é inválido.")]
        [Display(Name = "E-mail do funcionário")]
        public string? Emailfun { get; set; }
    }
}
