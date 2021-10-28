using Caliburn.Light;
using NetDimension.NanUI;
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtuesoft.Monitoring.AliyunService.Extensions
{
    public static class SimpleContainerExtensions
    {
        /// <summary>
        /// 添加一个瞬时服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static SimpleContainer AddTransient<T>(this SimpleContainer container)
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
        public static SimpleContainer AddTransient(this SimpleContainer container,Type type)
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
        public static SimpleContainer AddSingleton(this SimpleContainer container, Type type)
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
        public static SimpleContainer AddSingleton<T>(this SimpleContainer container)
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
        public static SimpleContainer AddSingleton<T>(this SimpleContainer container,T instance)
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
        public static TService GetService<TService>(this SimpleContainer container)
        => container.GetInstance<TService>(nameof(TService));
        /// <summary>
        /// 获取一个服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IEnumerable<TService> GetServices<TService>(this SimpleContainer container)
        => container.GetAllInstances<TService>();
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="javaScript"></param>
        /// <returns></returns>
        public static SimpleContainer? ServiceProvider(this JavaScriptExtensionBase javaScript)
            => WinFormium.Runtime?.Container;
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static SimpleContainer? ServiceProvider(this Formium form)
            => WinFormium.Runtime?.Container;
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static SimpleContainer? ServiceProvider(this ApplicationContext app)
            => WinFormium.Runtime?.Container;
        /// <summary>
        /// 获取服务容器
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static SimpleContainer? ServiceProvider(this DataService  service)
            => WinFormium.Runtime?.Container;
        
    }
}
