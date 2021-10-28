using Caliburn.Light;
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtuesoft.Monitoring.AliyunService.Extensions;

namespace Virtuesoft.Monitoring.AliyunService.DataServices
{
    [DataRoute("/aliyun/region")]
    public class AliyunRegionService : DataService
    {
        AlibabaCloud.SDK.Ecs20140526.Client? Aliyun { get; }

        public AliyunRegionService() => Aliyun = this.ServiceProvider()?.GetService<AlibabaCloud.SDK.Ecs20140526.Client>();
        /// <summary>
        /// 获取当所有区域
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResourceResponse get(ResourceRequest request) {
            var result = Aliyun?.DescribeRegions(new AlibabaCloud.SDK.Ecs20140526.Models.DescribeRegionsRequest()
            {
            });
            return Json(result?.Body.Regions);
        }
    }
}
