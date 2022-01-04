using AlibabaCloud.SDK.Ecs20140526;
using NetDimension.NanUI.Browser.ResourceHandler;
using NetDimension.NanUI.Resource.Data;
using Virtuesoft.Monitoring.AliyunService.Extensions;

namespace Virtuesoft.Monitoring.AliyunService.DataServices
{
    /// <summary>
    /// 主机相关操作
    /// </summary>
    [DataRoute("/aliyun/ecs")]
    public class AliyunEcsService : DataService
    {
        Client? Aliyun { get; }

        public AliyunEcsService() => Aliyun = this.ServiceProvider()?.GetService<Client>();

        public ResourceResponse get(ResourceRequest request)
        {
            var data = Aliyun?.DescribeInstances(new AlibabaCloud.SDK.Ecs20140526.Models.DescribeInstancesRequest()
            {
                RegionId = request.QueryString["region"],
                PageSize = 25
            });
            return Json(data?.Body.Instances);
        }
        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResourceResponse resboot(ResourceRequest request) {
            var data = Aliyun?.RebootInstance(new AlibabaCloud.SDK.Ecs20140526.Models.RebootInstanceRequest()
            {
                InstanceId = request.QueryString["id"]
            });
            return StatusCode(200);
        }
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResourceResponse start(ResourceRequest request)
        {
            var data = Aliyun?.StartInstance(new AlibabaCloud.SDK.Ecs20140526.Models.StartInstanceRequest()
            {
                InstanceId = request.QueryString["id"]
            });
            return StatusCode(200);
        }
        /// <summary>
        /// 强制关机
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResourceResponse stop(ResourceRequest request)
        {
            var data = Aliyun?.StopInstance(new AlibabaCloud.SDK.Ecs20140526.Models.StopInstanceRequest()
            {
                InstanceId = request.QueryString["id"],
                ForceStop=true
            });
            return StatusCode(200);
        }
    }
}
