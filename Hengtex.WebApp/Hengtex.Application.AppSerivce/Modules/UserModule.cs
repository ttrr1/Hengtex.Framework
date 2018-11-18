using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.Entity.WebApp;
using Nancy.Responses.Negotiation;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hengtex.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.05.04 13:57
    /// 描 述:登录接口
    /// </summary>
    public class UserModule : BaseModule
    {
        private UserCache userCache = new UserCache();
        private AppAuthorizeBLL appAuthorizeBLL = new AppAuthorizeBLL(); 
        public UserModule()
            : base("/hengtex/api")
        {
            Post["/user/modifyPassword"] = ModifyPassword;//暂时有问题
            Post["/user/getUserList"] = GetUserList;
            Post["/user/getUserModuleList"] = GetUserModuleList;
        }
        /// <summary>
        /// 修改密码接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator ModifyPassword(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Leave);
                }
                else
                {
                    this.RomveCache(recdata.userid);
                    return this.SendData(ResponseType.Success, "用户退出成功");
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetUserList(dynamic _)
        {
            try{
                var recdata = this.GetModule<ReceiveModule>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = userCache.GetListToApp();
                    return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch { 
                return this.SendData(ResponseType.Fail, "异常");
            }   
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetUserModuleList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<AppUserEntity>>();
                
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();
                    string account = recdata.data.Account;
                    IEnumerable<AppModuleEntity> modules = appAuthorizeBLL.GetModuleList(recdata.userid,recdata.data.DomainName);
                    //int cnt = 0;
                    //using (IEnumerator<AppModuleEntity> enumerator = modules.GetEnumerator())
                    //{    while (enumerator.MoveNext())
                    //    cnt++;
                    //}
                    //var data= new
                    //{
                    //    modules = modules,
                    //    records = cnt,
                    //};
                    return this.SendData<IEnumerable<AppModuleEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);


                    //var data = userCache.GetListToApp();
                    //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
    }
}