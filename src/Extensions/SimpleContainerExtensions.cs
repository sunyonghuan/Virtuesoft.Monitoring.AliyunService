using NetDimension.NanUI;
using NetDimension.NanUI.JavaScript;
using NetDimension.NanUI.JavaScript.WindowBinding;
using NetDimension.NanUI.Resource.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtuesoft.Monitoring.AliyunService.Extensions
{
    public static class ServiceContainerExtensions
    {
        /// <summary>
        /// 添加一个瞬时服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static ServiceContainer AddTransient<T>(this ServiceContainer container)
        {
            container.RegisterPerRequest<T>(nameof(T));
            return container;
        }
        /// <summary>
        /// 添加一个瞬时服务
        /// </summary>
        /// <param name="container"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ServiceContainer AddTransient(this ServiceContainer container,Type type)
        {
            container.RegisterPerRequest(type, type, type.FullName);
            return container;
        }
        /// <summary>
        /// 添加单件服务
        /// </summary>
        /// <param name="container"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ServiceContainer AddSingleton(this ServiceContainer container, Type type)
        {
            container.RegisterSingleton(type, type, type.FullName);
            return container;
        }
        /// <summary>
        /// 添加单件服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static ServiceContainer AddSingleton<T>(this ServiceContainer container)
        {
            container.RegisterSingleton<T>(nameof(T));
            return container;
        }
        /// <summary>
        /// 添加单件服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static ServiceContainer AddSingleton<T>(this ServiceContainer container,T instance)
        {
            container.RegisterInstance<T>(instance,nameof(T));
            return container;
        }
        /// <summary>
        /// 获取一个服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static TService GetService<TService>(this ServiceContainer container)
        => container.GetInstance<TService>(nameof(TService));
        /// <summary>
        /// 获取一个服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IEnumerable<TService> GetServices<TService>(this ServiceContainer container)
        => container.GetAllInstances<TService>();
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="javaScript"></param>
        /// <returns></returns>
        public static ServiceContainer? ServiceProvider(this JavaScriptWindowBindingObject javaScript)
            => WinFormium.Runtime?.Container;
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static ServiceContainer? ServiceProvider(this Formium form)
            => WinFormium.Runtime?.Container;
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static ServiceContainer? ServiceProvider(this ApplicationContext app)
            => WinFormium.Runtime?.Container;
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static ServiceContainer? ServiceProvider(this DataService  service)
            => WinFormium.Runtime?.Container;
        
    }
}
