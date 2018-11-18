using Hengtex.Application.Busines.PublicInfoManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.Entity.PublicInfoManage;
using Hengtex.Application.Entity.SystemManage.ViewModel;
using Nancy.Responses.Negotiation;
using System;
using System.Collections.Generic;

namespace Hengtex.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.05.12 13:57
    /// 描 述:数据字典接口
    /// </summary>
    public class CommonModule:BaseModule
    {
        private DataItemCache dataItemCache = new DataItemCache();
        private NewsBLL newsBll = new NewsBLL();
        public CommonModule()
            : base("/hengtex/api")
        {
            Post["/common/getSrvTime"] = srvTime;
            Post["/common/getAnnounces"] = getAnnouncesList;
        }
        /// <summary>
        /// 获取数据字典列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator srvTime(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<DataItemQuery>>();
            bool resValidation = this.DataValidation(recdata.userid, recdata.token);
            if (!resValidation)
            {
                return this.SendData(ResponseType.Fail, "无该用户登录信息");
            }
            else
            {
                var data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//dataItemCache.GetDataItemList(recdata.data.enCode);
                return this.SendData<string>(data, recdata.userid, recdata.token, ResponseType.Success);
            }
         
        }


        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator getAnnouncesList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<UserEntity>>();

                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();
                    string account = recdata.data.Account;
                    IEnumerable<NewsEntity> modules = newsBll.GetNewsListByTopCount("5");

                    return this.SendData<IEnumerable<NewsEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
    }
    
}