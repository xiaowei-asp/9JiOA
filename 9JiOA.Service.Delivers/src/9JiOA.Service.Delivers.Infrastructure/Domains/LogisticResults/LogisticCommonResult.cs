
namespace _9JiOA.Service.Delivers.Infrastructure.Domains
{
    public class LogisticCommonResult<T>
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 提示消息
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result {  get; set; }
    }
}
