using Caliburn.Light;
using Microsoft.Extensions.Configuration;
using NetDimension.NanUI;
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.LocalFileResource;
using Virtuesoft.Monitoring.AliyunService.Extensions;

namespace Virtuesoft.Monitoring.AliyunService
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            WinFormium.CreateRuntimeBuilder(env =>
            {
                //env.ForceHighDpiSupportDisabled();
                env.CustomCefSettings(settings =>
                {
                    settings.WindowlessRenderingEnabled = true;
                });
                env.CustomCefCommandLineArguments(commandLine =>
                {
                    // 在此处指定 CEF 命令行参数
                });

            }, app =>
            {
#if DEBUG
                app.UseDebuggingMode();
#endif
                app
                .UseConfiguration()
                .UseConfiguraService(ConfiguaAliyunServices)
                .UseFormiums()
                .UseMainWindow(context =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    return context.ServiceProvider()?.GetService<MainWindow>();
                })
                .UseSingleInstance(() =>
                {
                    MessageBox.Show("已经打开软件,请勿重复打开", "系统提示");
                })
                .UseLocalFileResource("http", "page.cloud.zpay", Path.Combine(Application.StartupPath, "wwwroot"))
                .UseDataServiceResource("http", "api.cloud.zpay");
            })
            .Build()
            .Run();
        }
        /// <summary>
        /// 配置Aliyun需要的服务
        /// </summary>
        /// <param name="services"></param>
        public static void ConfiguaAliyunServices(SimpleContainer services)
        {
            //阿里云监控配置
            var cmsConfig = services.GetService<IConfiguration>().GetSection("aliyun.cms");
            var aliyunCmsConfig = new AlibabaCloud.OpenApiClient.Models.Config()
            {
                AccessKeyId = cmsConfig["AccessKeyId"],
                AccessKeySecret = cmsConfig["AccessKeySecret"],
                RegionId = cmsConfig["RegionId"],
                Endpoint = cmsConfig["Endpoint"]
            };
            var aliyunCms = new AlibabaCloud.SDK.Cms20190101.Client(aliyunCmsConfig);
            services.AddSingleton(aliyunCms);
            //阿里云ecs
            var ecsConfig = services.GetService<IConfiguration>().GetSection("aliyun.ecs") ;
            var aliyunEcsConfig=new AlibabaCloud.OpenApiClient.Models.Config()
            {
                AccessKeyId = ecsConfig["AccessKeyId"],
                AccessKeySecret = ecsConfig["AccessKeySecret"],
                RegionId = ecsConfig["RegionId"],
                Endpoint = ecsConfig["Endpoint"]
            };
            var aliyunEcs = new AlibabaCloud.SDK.Ecs20140526.Client(aliyunEcsConfig);
            services.AddSingleton(aliyunEcs);
        }
    }
}