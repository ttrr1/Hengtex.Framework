using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Code;
using Hengtex.Cache.Factory;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Hengtex.Application.Entity.WebApp;

namespace Hengtex.Application.Cache
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2016.3.4 9:56
    /// 描 述：用户信息缓存
    /// </summary>
    public class AppUserCache
    {
        private AppUserBLL busines = new AppUserBLL();

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppUserEntity> GetList()
        {
            IEnumerable<AppUserEntity> data = new List<AppUserEntity>();
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<AppUserEntity>>(busines.cacheKey);
            if (cacheList == null)
            {
                data = busines.GetList();
                CacheFactory.Cache().WriteCache(data, busines.cacheKey);
            }
            else
            {
                data = cacheList;
            }
            return data;
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns></returns>
        public IEnumerable<AppUserEntity> GetList(string departmentId)
        {
            var data = this.GetList();
            //if (!string.IsNullOrEmpty(departmentId))
            //{
            //    data = data;
            //}
            return data;
        }
        public Dictionary<string,appUserInfoModel> GetListToApp()
        {
            Dictionary<string, appUserInfoModel> data = new Dictionary<string,appUserInfoModel>();
            var datalist = this.GetList();
            foreach (var item in datalist)
            {
                appUserInfoModel one = new appUserInfoModel {
                    UserId = item.isid.ToString(),
                    Account = item.Account,
                    RealName = item.UserName,
                    OrganizeId = "",
                    DepartmentId = ""
                };
                data.Add(item.isid.ToString(), one);
            }

            return data;
        }
    }
}
