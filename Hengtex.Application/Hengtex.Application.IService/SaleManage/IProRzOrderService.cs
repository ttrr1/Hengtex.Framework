using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.Sale;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// 描 述：样品档案管理
    /// </summary>
    public interface IProRzOrderService
    {
        #region 获取数据
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProRzOrderEntity> GetList();
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<ProRzOrderEntity> GetPageList(Pagination pagination, string queryJson, string user);
        DataTable GetPageListByDt(Pagination pagination, string queryJson, string user);

        DataTable GetDeliveryByNums(string user);
        DataTable GetPacksByNums(string user);

        DataTable GetBatchesData(string batches);
        /// <summary>
        /// 样品实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ProRzOrderEntity GetEntity(string keyValue);
        #endregion

        #region 验证数据
       
       
        #endregion

        #region 提交数据
      
        #endregion
    }
}
