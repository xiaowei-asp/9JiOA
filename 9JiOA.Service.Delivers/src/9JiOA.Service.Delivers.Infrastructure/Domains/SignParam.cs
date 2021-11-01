
namespace _9JiOA.Service.Delivers.Infrastructure.Domains
{
    public class SignParam
    {
        /// <summary>
        /// 密钥Key
        /// </summary>
        public string AppKey {  get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string AppSecret {  get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp {  get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version {  get; set; }

        /// <summary>
        /// 请求Token
        /// </summary>
        public string AccessToken {  get; set; }

        /// <summary>
        /// 调用方法
        /// </summary>
        public string Method {  get; set; }
    }
}
