using AlibabaCloud.SDK.BssOpenApi20171214;
using NetDimension.NanUI.Browser.ResourceHandler;
using NetDimension.NanUI.Resource.Data;
using Virtuesoft.Monitoring.AliyunService.Extensions;

namespace Virtuesoft.Monitoring.AliyunService.DataServices
{
    /// <summary>
    /// 账单相关
    /// </summary>
    [DataRoute("/aliyun/bill")]
    public class AliyunBillingService : DataService
    {
        Client? Aliyun { get; }

        public AliyunBillingService() => Aliyun = this.ServiceProvider()?.GetService<Client>();

        public ResourceResponse balance(ResourceRequest request)
        {
            var data = Aliyun?.QueryAccountBalance();
            return Json($"{data?.Body.Data.AvailableAmount} {data?.Body.Data.Currency}");
        }
    }
}
