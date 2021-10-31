using _9JiOA.Service.Identitys.Infrastructure.AggregateRoots.Users;

namespace _9JiOA.Service.Identitys.Services
{
    public interface ICustomerServices
    {
        UserInfoDto AddUserInfo(UserInfoDto dto);

        UserInfoDto GetUserInfoById(string id);
        UserInfoDto GetUserInfoByName(string name);
    }
}
