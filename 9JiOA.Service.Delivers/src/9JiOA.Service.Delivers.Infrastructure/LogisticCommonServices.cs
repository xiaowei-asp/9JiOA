using _9JiOA.Service.Delivers.Infrastructure.Domains;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _9JiOA.Service.Delivers.Infrastructure
{
    public class LogisticCommonServices
    {
        /// <summary>
        /// 生产签名
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string GenerateSignature(SignParam param,string json)
        {
            var signStr = string.Concat(param.AppKey, "access_token", accessToken, "app_key", appKey,
                "method", method, "param_json", paramJson, "timestamp", timestamp, "v", version, appSecret);



            // 第三步：使用MD5加密
            var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(signStr));

            // 第四步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
            return Sign(content);
        }
    }
}
