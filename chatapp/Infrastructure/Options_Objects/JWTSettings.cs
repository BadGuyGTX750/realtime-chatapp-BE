namespace chatapp.Infrastructure.Options_Objects
{
    public class JWTSettings
    {
        public string Secret { get; init; }

        public string Issuer { get; init; }

        public string Audience { get; init; }

        public int TokenExpirationMinutes { get; init; }

        public int RefreshTokenExpirationDays { get; init; }
    }
}
