namespace SecuritySample1.Models.Dto
{
    //Dto for Open Redirect Attacks
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
