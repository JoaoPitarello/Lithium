using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Producao
    {
        [Required(ErrorMessage = "É obrigatório o início da produção.")]
        [Display(Name = "Início da produção")]
        public DateTime IniProdu { get; set; }

        [Required(ErrorMessage = "É obrigatório o fim da produção.")]
        [Display(Name = "Fim da produção")]
        public DateTime FimProdu { get; set; }

        [Required(ErrorMessage = "É obrigatória a quantidade de material.")]
        [Display(Name = "Quantidade de materiais usados")]
        public string? QtdProdu { get; set; }

        [Required(ErrorMessage = "O funcionario é obrigatório.")]
        [Display(Name = "ID do Funcionario")]
        public int Fkfuncionarioid { get; set; }
    }
}
