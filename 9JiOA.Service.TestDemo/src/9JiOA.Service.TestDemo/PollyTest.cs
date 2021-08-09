using NUnit.Framework;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _9JiOA.Service.TestDemo
{
    /// <summary>
    /// Pooly测试
    /// </summary>
    public class PollyTest
    {
        [Test]
        public void PollyRetry()
        {
            // Retry multiple times, calling an action on each retry 
            // with the current exception and retry count
            var result = string.Empty;
            var i = 0;
            Policy.HandleResult<bool>(string.IsNullOrWhiteSpace(result))
                .Retry(3, (reponse, retryCount, context) =>
                {
                    //call back
                    //錯誤發生後要做的事
                    Console.WriteLine(i++);
                    result = "1";
                });
        }
    }
}
