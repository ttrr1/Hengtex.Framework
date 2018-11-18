using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
//using Hengtex.Application.Entity.AppManage.ViewModel;
using Hengtex.Application.Entity.AuthorizeManage.ViewModel;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.Service.AppManage;
using Hengtex.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.5 22:35
    /// 描 述：授权认证
    /// </summary>
    public class AppAuthorizeBLL
    {
        private IAppAuthorizeService service = new AppAuthorizeService();
        private AppModuleBLL moduleBLL = new AppModuleBLL();
        private AppModuleButtonBLL moduleButtonBLL = new AppModuleButtonBLL();
        private AppModuleColumnBLL moduleColumnBLL = new AppModuleColumnBLL();

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleEntity> GetModuleList(string userId)
        {
            if (OperatorProvider.Provider.Current().IsSystem)
            {
                return moduleBLL.GetList().FindAll(t => t.EnabledMark.Equals(1));
            }
            else
            {
                return service.GetModuleList(userId);
            }
        }

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleEntity> GetModuleList(string userId,string menuName)
        {
            if (OperatorProvider.Provider.Current().IsSystem)
            {
                return moduleBLL.GetList().FindAll(t => t.EnabledMark.Equals(1));
            }
            else
            {
                return service.GetModuleList(userId, menuName);
            }
        }

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleButtonEntity> GetModuleButtonList(string userId)
        {
            if (OperatorProvider.Provider.Current().IsSystem)
            {
                return moduleButtonBLL.GetList();
            }
            else
            {
                return service.GetModuleButtonList(userId);
            }
        }
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleColumnEntity> GetModuleColumnList(string userId)
        {
            if (OperatorProvider.Provider.Current().IsSystem)
            {
                return moduleColumnBLL.GetList();
            }
            else
            {
                return service.GetModuleColumnList(userId);
            }
        }
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeUrlModel> GetUrlList(string userId)
        {
            return service.GetUrlList(userId);
        }
        /// <summary>
        /// Action执行权限认证
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleId">模块Id</param>
        /// <param name="action">请求地址</param>
        /// <returns></returns>
        public bool ActionAuthorize(string userId, string moduleId, string action)
        {
            List<AuthorizeUrlModel> authorizeUrlList = new List<AuthorizeUrlModel>();
            var cacheList = CacheFactory.Cache().GetCache<List<AuthorizeUrlModel>>("AuthorizeUrl_" + userId);
            if (cacheList == null)
            {
                authorizeUrlList = this.GetUrlList(userId).ToList();
                CacheFactory.Cache().WriteCache(authorizeUrlList, "AuthorizeUrl_" + userId, DateTime.Now.AddMinutes(1));
            }
            else
            {
                authorizeUrlList = cacheList;
            }
            authorizeUrlList = authorizeUrlList.FindAll(t => t.ModuleId.Equals(moduleId));
            foreach (AuthorizeUrlModel item in authorizeUrlList)
            {
                if (!string.IsNullOrEmpty(item.UrlAddress))
                {
                    string[] url = item.UrlAddress.Split('?');
                    if (item.ModuleId == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(Operator operators, bool isWrite = false)
        {
            return service.GetDataAuthorUserId(operators, isWrite);
        }
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(Operator operators, bool isWrite = false)
        {
            return service.GetDataAuthor(operators, isWrite);
        }
    }
}
