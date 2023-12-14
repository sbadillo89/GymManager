namespace GymManager.Entities.Auth
{
    public record AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
    }
}