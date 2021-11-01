using System;
using System.Collections.Generic;
using System.Text;

namespace _9JiOA.Service.Delivers.Infrastructure
{
    public class JDLogistics:LogisticsInterface
    {
        public override TResult CreateOrder<TResult, TParam>(TParam param)
        {
            return base.CreateOrder<TResult, TParam>(param);
        }
    }
}
