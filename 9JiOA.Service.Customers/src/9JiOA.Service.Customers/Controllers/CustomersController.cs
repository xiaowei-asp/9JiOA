using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9JiOA.Service.Customers.Infrastructure.AggregateRoots;
using _9JiOA.Service.Customers.Services;
using ASample.NetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _9JiOA.Service.Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        public ICustomerServices CustomerServices { get; }

        public CustomersController(ILogger<CustomersController> logger,ICustomerServices customerServices)
        {
            _logger = logger;
            CustomerServices = customerServices;
        }


        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("query")]
        public ApiRequestResult GetList()
        {
            var userList = CustomerServices.GetUserList();
            if(!userList.Any())
                return ApiRequestResult.Error("未查询到用户信息");
            return ApiRequestResult.Success(userList, "获取用户信息成功");
        }

        /// <summary>
        /// 通过用户Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("get-user/{userId}")]
        public ApiRequestResult GetUserInfo(string userId)
        {
            var userDto = CustomerServices.GetUserById(userId);
            if(userDto == null)
                return ApiRequestResult.Error("未查询到用户信息");
            return ApiRequestResult.Success(userDto,"获取用户信息成功");
        }
    }
}
