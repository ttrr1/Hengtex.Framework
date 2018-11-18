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
    public interface IFclt_facilitiesService
    {
        #region 获取数据

        /// <summary>
        /// 工序权限表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Fclt_facilitiesEntity> GetList(Dictionary<string, string> fields);

        IEnumerable<Fclt_facilitiesEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 工序实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Fclt_facilitiesEntity GetEntity(string keyValue);
        #endregion

        #region 验证数据
       
       
        #endregion

        #region 提交数据
      
        #endregion
    }
}
