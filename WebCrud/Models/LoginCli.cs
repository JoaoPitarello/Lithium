using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Cliente
    {
        [Display(Name = "Nome do Cliente")]
        public string? NomeCli { get; set; }

        [Display(Name = "Email do Cliente")]
        public string? EmailCli { get; set; }

        [Display(Name = "Endereco do Cliente")]
        public string? EnderecoCli { get; set; }

        [Display(Name = "Telefone do Cliente")]
        public string? TelefoneCli { get; set; }
    }
}
