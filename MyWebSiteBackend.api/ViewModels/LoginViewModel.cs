namespace MyWebSiteBackend.api.ViewModels
{
     public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
        public string Token { get; set; }
    }
}
