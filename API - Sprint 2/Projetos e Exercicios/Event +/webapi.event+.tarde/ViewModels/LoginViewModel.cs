using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webapi.event_.tarde.Domains;

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