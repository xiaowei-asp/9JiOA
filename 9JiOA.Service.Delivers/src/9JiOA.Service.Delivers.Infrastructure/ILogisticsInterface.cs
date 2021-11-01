
namespace _9JiOA.Service.Delivers.Infrastructure
{
    public interface ILogisticsInterface
    {
        /// <summary>
        /// 创建物流单
        /// </summary>
        /// <typeparam name="Result">返回结果</typeparam>
        /// <typeparam name="Param">入参</typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        TResult CreateOrder<TResult, TParam>(TParam param);

        /// <summary>
        /// 取消物流单
        /// </summary>
        /// <typeparam name="Result">返回结果</typeparam>
        /// <typeparam name="Param">入参</typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        TResult CancelOrder<TResult, TParam>(TParam param);

        /// <summary>
        /// 查询路由轨迹
        /// </summary>
        /// <typeparam name="Result">返回结果</typeparam>
        /// <typeparam name="Param">入参</typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        TResult QueryTrace<TResult, TParam>(TParam param);


        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <typeparam name="Result">返回结果</typeparam>
        /// <typeparam name="Param">入参</typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        TResult QueryOrder<TResult, TParam>(TParam param);
    }
}
