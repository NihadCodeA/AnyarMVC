namespace AnyarMVC.Models
{
    public class TeamSocialMediaAccount
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string SocialMediaLink  {get; set; }
        public string SocialMediaIcon  {get; set; }
        public Team? Team { get; set; }
    }
}
