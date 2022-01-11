# 阿里云监控

阿里云监控，支持 ECS 的启动、停止、重启等操作。云监控支持查看内存和 CPU 使用情况。

## 使用方法

修改应用程序目录中的 app.json 文件。

附：[常用Region查询](https://help.aliyun.com/document_detail/140601.html)

```JSON
{
    //云监控配置
    "aliyun.cms": {
        "AccessKeyId": "",
        "AccessKeySecret": "",
        "RegionId": "", // 区域设置，这个配置没用上，会自动获取当前所有区域。
        "Endpoint": "" // 云监控节点设置，如：metrics.cn-hongkong.aliyuncs.com，格式为 metrics.区域.aliyuncs.com，具体到官网看
    },
    //ecs管理配置
    "aliyun.ecs": {
        "AccessKeyId": "",
        "AccessKeySecret": "",
        "RegionId": "",
        "Endpoint": "" //节点设置，如:ecs.aliyuncs.com，具体到官网看
    }
}
```




