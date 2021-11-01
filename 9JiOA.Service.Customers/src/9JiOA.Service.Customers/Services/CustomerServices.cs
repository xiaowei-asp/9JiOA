using _9JiOA.Service.Customers.Infrastructure.AggregateRoots;
using ASample.NetCore.Extension;
using ASample.NetCore.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _9JiOA.Service.Customers.Services
{
    public class CustomerServices : ICustomerServices
    {
        public CustomerServices(IASampleRedisCache aSampleRedisCache)
        {
            ASampleRedisCache = aSampleRedisCache;
        }

        public IASampleRedisCache ASampleRedisCache { get; }

        public UserInfoDto GetUserById(string id)
        {
            var userInfoStrs = ASampleRedisCache.GetString("customer-list");
            var userInfoList = new List<UserInfoDto>();
            var dto = new UserInfoDto();
            if (userInfoStrs.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                userInfoList = JsonConvert.DeserializeObject<List<UserInfoDto>>(userInfoStrs);
                if (userInfoList != null)
                {
                    dto = userInfoList.FirstOrDefault(c => c.Id == id);
                }
            }
            return dto;
        }

        public List<UserInfoDto> GetUserList()
        {
            var userInfoStrs = ASampleRedisCache.GetString("customer-list");
            var userInfoList = new List<UserInfoDto>();
            if (!userInfoStrs.IsNullOrEmpty())
            {
                userInfoList = JsonConvert.DeserializeObject<List<UserInfoDto>>(userInfoStrs);
            }
            return userInfoList;
        }
    }
}
