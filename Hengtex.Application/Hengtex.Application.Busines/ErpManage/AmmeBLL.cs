using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Cache.Factory;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：电表档案管理
    /// </summary>
    public class AmmeBLL
    {
        private IAmmeService service = new AmmeService();
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "AppRoleCache";

        #region 获取数据
        /// <summary>
        /// 电表档案列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AmmeEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 电表档案列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AmmeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        

        /// <summary>
        /// 电表档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AmmeEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

    }
}
