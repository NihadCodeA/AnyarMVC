using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyarMVC.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [StringLength(maximumLength:50)]
        public string Fullname { get; set; }
        [StringLength(maximumLength:50)]
        public string Postion { get; set; }
        [StringLength(maximumLength:200)]
        public string About { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public List<TeamSocialMediaAccount>? SocialMediaAccounts { get; set;}
    }
}
