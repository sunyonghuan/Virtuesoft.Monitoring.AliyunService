using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace Virtuesoft.Monitoring.AliyunService.Extensions
{
    public static class ApplicationConfigurationBuilderExtensions
    {
        /// <summary>
        /// 添加配置文件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ApplicationConfigurationBuilder UseConfiguration(this ApplicationConfigurationBuilder app, string configureName = "app.json") 
            => app.Use(builder => {
                return (runtime, props) => {
                    var path = Path.Combine(WinFormium.ApplicationRunningDirectory, configureName);
                    if(!File.Exists(path))throw new FileNotFoundException($"{configureName} 文件不存在");
                    IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(WinFormium.ApplicationRunningDirectory)
                    .AddJsonFile(configureName, optional: false, reloadOnChange: true)
                    .Build();
                    runtime.Container.AddSingleton<IConfiguration>(configurationRoot);
                };
            }, ExtensionExecutePosition.MainProcessInitilized);


        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ApplicationConfigurationBuilder UseConfiguraService(this ApplicationConfigurationBuilder app, Action<ServiceContainer>? configuration = null) 
           => app.Use(builder => {
               return (runtime, props) => {
                   configuration?.Invoke(runtime.Container);
               };
           }, ExtensionExecutePosition.MainProcessInitilized);
        
        /// <summary>
        /// 添加所有的窗体到容器
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static ApplicationConfigurationBuilder UseFormiums(this ApplicationConfigurationBuilder app)
        =>app.Use(builder => {
                return (runtime, props) => {
                    var services = runtime.Container;
                    var assemblys = AppDomain.CurrentDomain.GetAssemblies();
                    assemblys
                .Select(t => t.GetTypes().Where(a => a.BaseType == typeof(Formium)))
                .ToList()
                .ForEach(assembly => {
                    foreach (var form in assembly)
                    {
                        try
                        {
                            services.AddTransient(form);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                });

                };
            }, ExtensionExecutePosition.MainProcessInitilized);
        
    }
}
