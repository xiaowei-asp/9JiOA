using System;
using System.Collections.Generic;
using System.Text;

namespace _9JiOA.Service.Delivers.Infrastructure
{
    public class LogisticsInterface : ILogisticsInterface
    {
        public virtual TResult CancelOrder<TResult, TParam>(TParam param)
        {
            throw new NotImplementedException();
        }

        public virtual TResult CreateOrder<TResult, TParam>(TParam param)
        {
            throw new NotImplementedException();
        }

        public virtual TResult QueryOrder<TResult, TParam>(TParam param)
        {
            throw new NotImplementedException();
        }

        public virtual TResult QueryTrace<TResult, TParam>(TParam param)
        {
            throw new NotImplementedException();
        }
    }
}
