using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório!")]
        public string? Senha { get; set; }
    }
}