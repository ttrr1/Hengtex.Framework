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
    /// 描 述：部门信息缓存
    /// </summary>
    public class AppDepartmentCache
    {
        private AppDepartmentBLL busines = new AppDepartmentBLL();

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppDepartmentEntity> GetList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<AppDepartmentEntity>>(busines.cacheKey);
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
        /// 部门列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns></returns>
        public IEnumerable<AppDepartmentEntity> GetList(string organizeId)
        {
            var data = this.GetList();
            //if (!string.IsNullOrEmpty(organizeId))
            //{
            //    data = data.Where(t => t.OrganizeId == organizeId);
            //}
            return data;
        }

        public AppDepartmentEntity GetEntity(string departmentId)
        {
            var data = this.GetList();
            if(!string.IsNullOrEmpty(departmentId))
            {
                var d = data.ToList<AppDepartmentEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new AppDepartmentEntity();
        }
    }
}
