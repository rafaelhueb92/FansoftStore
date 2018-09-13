using System.ComponentModel.DataAnnotations;

namespace Fansoft.Store.UI.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(100)]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)", ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100)]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }

    }
}
