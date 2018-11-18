using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hengtex.Application.Cache
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2016.3.4 9:56
    /// 描 述：组织架构缓存
    /// </summary>
    public class AppOrganizeCache
    {
        private AppOrganizeBLL busines = new AppOrganizeBLL();

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppOrganizeEntity> GetList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<AppOrganizeEntity>>(busines.cacheKey);
            if (cacheList == null)
            {
                var data = busines.GetList();
                CacheFactory.Cache().WriteCache(data, busines.cacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
        /// <summary>
        /// 组织列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns></returns>
        public AppOrganizeEntity GetEntity(string organizeId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                var d = data.Where(t => t.OrganizeId == organizeId).ToList<AppOrganizeEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new AppOrganizeEntity();
        }
    }
}
