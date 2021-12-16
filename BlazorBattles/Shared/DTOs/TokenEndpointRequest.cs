namespace BlazorBattles.Shared.DTOs
{
    public class TokenEndpointRequest
    {
        public string ClientId { get; set; }

        public string Scope { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string GrantType { get; set; }
    }
}
