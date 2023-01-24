using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace AnyarMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required, StringLength(maximumLength: 50)]
        public string UserName { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
