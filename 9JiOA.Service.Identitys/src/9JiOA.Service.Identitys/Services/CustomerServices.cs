using _9JiOA.Service.Identitys.Infrastructure.AggregateRoots.Users;
using ASample.NetCore.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using ASample.NetCore.Extension;
using Newtonsoft.Json;

namespace _9JiOA.Service.Identitys.Services
{
    public class CustomerServices : ICustomerServices
    {
        public CustomerServices(IASampleRedisCache aSampleRedisCache)
        {
            ASampleRedisCache = aSampleRedisCache;
        }

        public IASampleRedisCache ASampleRedisCache { get; }

        public UserInfoDto AddUserInfo(UserInfoDto dto)
        {
            dto.Id = Guid.NewGuid().ToString();
            var userInfoStrs =  ASampleRedisCache.GetString("customer-list");
            var userInfoList = new List<UserInfoDto>();
            if (userInfoStrs.IsNullOrEmpty())
            {
                userInfoList.Add(dto);
            }
            else
            {
                userInfoList = JsonConvert.DeserializeObject<List<UserInfoDto>>(userInfoStrs);
                if (userInfoList != null)
                {
                    userInfoList.Add(dto);
                }
            }
            ASampleRedisCache.SetString("customer-list", JsonConvert.SerializeObject(userInfoList));
            return dto;
        }

        public UserInfoDto GetUserInfoById(string id)
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

        public UserInfoDto GetUserInfoByName(string name)
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
                    dto = userInfoList.FirstOrDefault(c => c.UserName == name);
                }
            }
            return dto;
        }
    }
}
