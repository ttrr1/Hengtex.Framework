using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.Sale;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Application.Service.SaleManage;
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
    /// 描 述：样品管理
    /// </summary>
    public class ProRbStockDetailsBLL
    {
        private IProRbStockDetailsService service = new ProRbStockDetailsService();
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "AppRoleCache";

        #region 获取数据
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProRbStockDetailsEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProRbStockDetailsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 样品实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProRbStockDetailsEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

    }
}
