using _9JiOA.Service.Delivers.Infrastructure.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9JiOA.Service.Delivers.Infrastructure.Services
{
    public class JingdongLogisticServices
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TParam"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        public static LogisticCommonResult<JingdongCreateOrderResult> CreateOrder(JingdongCreateOrderParam param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static LogisticCommonResult<JingdongCancelOrderResult> CancelOrder(JingdongCancelOrderParam param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TParam"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        public static LogisticCommonResult<JingdongQueryOrderResult> QueryOrder(JingdongQueryOrderParam param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询轨迹
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TParam"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        public static LogisticCommonResult<JingdongQueryTrackResult> QueryTrack(JingdongQueryTrackParam param)
        {
            throw new NotImplementedException();
        }
    }
}
