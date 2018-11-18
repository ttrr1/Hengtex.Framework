using Microsoft.AspNet.SignalR.Client;
using System.Threading;

namespace Hengtex.Util.SignalR
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.05.23 15:48
    /// 发送信息给hubs
    /// </summary
    public static class SendHubs
    {
        /// <summary>
        /// 调用hub方法
        /// </summary>
        /// <param name="methodName"></param>
        public static void callMethod(string methodName, params object[] args)
        {
            var hubConnection = new HubConnection(Hengtex.Util.Config.GetValue("SignalRUrl"));
            IHubProxy ChatsHub = hubConnection.CreateHubProxy("ChatsHub");
            bool done = false;
            hubConnection.Start().ContinueWith(task =>
            {
                if (!task.IsFaulted)
                    //连接成功调用服务端方法
                {
                    ChatsHub.Invoke(methodName, args);
                    done = true;
                } 
                else
                    done = true;
            });
            while (!done)
            {
                Thread.Sleep(100);
            }
            //结束连接
            hubConnection.Stop();
        }
    }
}
