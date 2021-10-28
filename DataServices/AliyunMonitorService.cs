using AlibabaCloud.SDK.Cms20190101;
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.ResourceHandler;
using Newtonsoft.Json.Linq;
using Virtuesoft.Framework.JsonExtensions;
using Virtuesoft.Monitoring.AliyunService.Extensions;


namespace Virtuesoft.Monitoring.AliyunService.DataServices
{
    [DataRoute("/aliyun/monitor")]
    public class AliyunMonitorService : DataService
    {
        Client? Aliyun { get; }

        public AliyunMonitorService() => Aliyun = this.ServiceProvider()?.GetService<Client>();
        /// <summary>
        /// 内存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResourceResponse memory(ResourceRequest request)
        {
            return Json(get(request.QueryString["id"], "memory_usedutilization", request.QueryString["period"]));
        }
        /// <summary>
        /// cpu
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResourceResponse cpu(ResourceRequest request)
        {
            var data = get(request.QueryString["id"], "cpu_total", request.QueryString["period"]);
            return Text(data);
        }
        /// <summary>
        /// 获取数据项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="m"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        protected string get(string id,string m= "cpu_total", string period="15") {
            try
            {
                var data = Aliyun?.DescribeMetricData(new AlibabaCloud.SDK.Cms20190101.Models.DescribeMetricDataRequest()
                {
                    Namespace = "acs_ecs_dashboard",
                    MetricName = m,
                    Dimensions = new { instanceId = id }.ToJson(),
                    Period = period
                });
                return data?.Body.Datapoints ?? "[]";
            }
            catch (Exception)
            {
                return "[]";
            }
            
        }
    }
}
