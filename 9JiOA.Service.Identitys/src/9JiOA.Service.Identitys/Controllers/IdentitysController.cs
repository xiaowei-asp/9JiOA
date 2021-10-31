using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _9JiOA.Service.Identitys.Infrastructure.AggregateRoots;
using _9JiOA.Service.Identitys.Infrastructure.AggregateRoots.Users;
using _9JiOA.Service.Identitys.Services;
using ASample.NetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace _9JiOA.Service.Identitys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentitysController : ControllerBase
    {
        private readonly ILogger<IdentitysController> _logger;

        public ICustomerServices CustomerServices { get; }

        public IdentitysController(ILogger<IdentitysController> logger,ICustomerServices customerServices)
        {
            _logger = logger;
            CustomerServices = customerServices;

        }

        [HttpGet("index")]
        public ApiRequestResult Index()
        {
            return ApiRequestResult.Success("localhost:5001");
        }

        [HttpPost("sign-in")]
        public ApiRequestResult SignIn(AuthUser user)
        {
            var userInfo = CustomerServices.GetUserInfoByName(user.UserName);
            if(userInfo == null)
            {
                return ApiRequestResult.Error("用户不存在，请先注册");
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(userInfo.AuthType));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userInfo.UserName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(audience: userInfo.Audience,
                                              issuer: userInfo.Issuer,
                                              claims: claims,
                                              expires: expirationDate,
                                              signingCredentials: credentials);

            var authToken = new AuthToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate
            };

            return ApiRequestResult.Success(authToken,"登录成功");
        }

        [HttpPost("sign-up")]
        public ApiRequestResult SignUp(UserInfoDto user)
        {
            var userInfo = CustomerServices.GetUserInfoByName(user.UserName);
            if(userInfo != null)
            {
                return ApiRequestResult.Error("该用户已存在");
            }
            var result = CustomerServices.AddUserInfo(user);
            return ApiRequestResult.Success(result,"注册成功");
        }

        [HttpGet("get-user/{userId}")]
        public ApiRequestResult GetUserInfo(string userId)
        {
            var result = CustomerServices.GetUserInfoById(userId);
            if(result == null)
                return ApiRequestResult.Error("未查询到用户信息");
            return ApiRequestResult.Success(result, "用户信息获取成功");
        }

        [HttpGet("exception")]
        public ApiRequestResult GetException()
        {
            throw new Exception("系统异常");
        }

        [HttpGet("timeout")]
        public ApiRequestResult GetTimeOut()
        {
            var thread = Thread.CurrentThread;
            thread.Name = "MainThread";
            Thread.Sleep(10000);// 挂起半秒
            return ApiRequestResult.Error("线程超时");
        }
    }
}
