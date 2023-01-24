using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace AnyarMVC.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required,StringLength(maximumLength:50)]
        public string UserName { get; set;}
        [Required,MinLength(8), DataType(DataType.Password)] 
        public string Password { get; set;}
    }
}
