# Virtuesoft.Monitoring.AliyunService
阿里云监控,支持ecs 启动 停止 重启,云监控 支持看内存和cpu 使用
修改app.json
{
//云监控配置
  "aliyun.cms": {
    "AccessKeyId": "",
    "AccessKeySecret": "",
    "RegionId": "",//cn-hongkong 区域,这个配置没用上,会自动获取当前所有区域
    "Endpoint": ""//云监控节点 如:metrics.cn-hongkong.aliyuncs.com , 格式为 metrics.区域.aliyuncs.com.具体到官网看
  },
//ecs管理配置
  "aliyun.ecs": {
    "AccessKeyId": "",
    "AccessKeySecret": "",
    "RegionId": "",
    "Endpoint": ""//节点 如:ecs.aliyuncs.com , 具体到官网看
  }
}
常用Region查询
https://help.aliyun.com/document_detail/140601.html
