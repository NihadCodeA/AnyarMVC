using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace AnyarMVC.ViewModels
{
    public class MemberRegisterViewModel
    {
        [Required, StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        [Required, StringLength(maximumLength: 100),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string UserName { get; set; }
        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MinLength(8),Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
