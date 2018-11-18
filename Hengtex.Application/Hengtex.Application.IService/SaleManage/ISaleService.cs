using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.Sale;
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
    /// 描 述：发货档案管理
    /// </summary>
    public interface ISaleService
    {
        #region 获取数据
        /// <summary>
        /// 发货列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<SampleEntity> GetList();
        /// <summary>
        /// 发货列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<SampleEntity> GetPageList(Pagination pagination, string queryJson);
      
        /// <summary>
        /// 发货实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        SampleEntity GetEntity(string keyValue);
        #endregion

        #region 验证数据
       
       
        #endregion

        #region 提交数据
      
        #endregion
    }
}
