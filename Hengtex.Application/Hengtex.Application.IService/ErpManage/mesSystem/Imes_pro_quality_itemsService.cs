using Hengtex.Application.Entity.ErpManage;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.IService.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2018 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2018.02.08
    /// 描 述：工序档案管理
    /// </summary>
    public interface Imes_pro_quality_itemsService
    {
        #region 获取数据

        /// <summary>
        /// <mes_pro_quality_items
        /// </summary>
        /// <param name="fields">查询</param>
        /// <returns></returns>
        IEnumerable<mes_pro_quality_itemsEntity> GetList(Dictionary<string, string> fields);


		/// <summary>
        /// <mes_pro_quality_items
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<mes_pro_quality_itemsEntity> GetPageList(Pagination pagination, string queryJson);
        
        /// <summary>
        /// <mes_pro_quality_items
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        mes_pro_quality_itemsEntity GetEntity(string keyValue);
        #endregion

        
    }
}