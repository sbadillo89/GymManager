namespace GymManager.Entities.Config
{
    public record JwtConfig
    {
        public string Secret { get; set; }
        public TimeSpan ExpiryTime { get; set; }
        public string TimeZone { get; set; }
    }
}