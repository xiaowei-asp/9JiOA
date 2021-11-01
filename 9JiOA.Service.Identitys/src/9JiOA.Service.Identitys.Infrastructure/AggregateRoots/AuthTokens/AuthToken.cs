using System;

namespace _9JiOA.Service.Identitys.Infrastructure.AggregateRoots
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
