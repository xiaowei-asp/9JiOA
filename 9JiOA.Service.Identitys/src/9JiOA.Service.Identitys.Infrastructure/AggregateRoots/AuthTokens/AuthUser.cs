namespace _9JiOA.Service.Identitys.Infrastructure.AggregateRoots
{
    public class AuthUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthType { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
