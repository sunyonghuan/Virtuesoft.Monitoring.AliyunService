using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtuesoft.Framework.JsonExtensions;
using Virtuesoft.Monitoring.AliyunService.Extensions;
using Virtuesoft.Monitoring.AliyunService.Properties;
namespace Virtuesoft.Monitoring.AliyunService
{
    internal class MainWindow : Formium
    {
        public override HostWindowType WindowType =>  HostWindowType.Borderless;
        private NotifyIcon notify;
        bool mustQuit = false;
        public override string StartUrl => "http://page.cloud.zpay/";
        public MainWindow()
        {
            Size = new Size(1024, 800);
            Mask.BackColor = Color.Transparent;
            Mask.Image = null;
            Title = "阿里云服务器监控";
            StartPosition = FormStartPosition.CenterScreen;
            BorderlessWindowProperties.BorderEffect = BorderEffect.None;
            BorderlessWindowProperties.ShadowEffect = ShadowEffect.None;
            ShowInTaskbar = false;

            var contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add(new ToolStripButton("退出", null, new EventHandler(ToolStripButton_退出_Click)) { 
             
            });
            
            notify = new NotifyIcon()
            {
                Text = "阿里云监控系統,双击显示",
                Icon = Resources.logo,
                ContextMenuStrip = contextMenuStrip
            };
            Icon = Resources.logo;
            notify.Visible = true;
            notify.DoubleClick += Notify_DoubleClick;
            this.BeforeClose += MainWindow_BeforeClose;

        }
        private void ToolStripButton_退出_Click(object? sender, EventArgs e) {
            mustQuit = true;
            //Application.Exit();
            //Application.ExitThread();
            //System.Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private void Notify_DoubleClick(object? sender, EventArgs e)
        {
            this.Show();
            Active();
        }

        private void MainWindow_BeforeClose(object? sender, NetDimension.NanUI.Browser.FormiumCloseEventArgs e)
        {
            if (mustQuit) return;
            e.Canceled = true;
            this.Hide();
            
        }
    }
}
