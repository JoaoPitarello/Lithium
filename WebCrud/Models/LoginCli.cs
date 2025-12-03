using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Cliente
    {
        // required indica que os campos são de preenchimento obrigatório
        [Required(ErrorMessage = "O Nome do Cliente é obrigatório.")]
        [Display(Name = "Nome do Cliente")]
        public string? NomeCli { get; set; }

        //usando email adress para indicar o modelo correto de inserir o email
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do Email é inválido.")]
        [Display(Name = "Email do Cliente")]
        public string? EmailCli { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [Display(Name = "Endereco do Cliente")]
        public string? EnderecoCli { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [Display(Name = "Telefone do Cliente")]
        public string? TelefoneCli { get; set; }
    }
}