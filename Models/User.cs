namespace MyApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}