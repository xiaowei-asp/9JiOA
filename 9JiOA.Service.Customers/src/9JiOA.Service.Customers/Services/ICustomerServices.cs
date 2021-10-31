using _9JiOA.Service.Customers.Infrastructure.AggregateRoots;
using System.Collections.Generic;

namespace _9JiOA.Service.Customers.Services
{
    public interface ICustomerServices
    {
        List<UserInfoDto> GetUserList();
        UserInfoDto GetUserById(string id);
    }
}
