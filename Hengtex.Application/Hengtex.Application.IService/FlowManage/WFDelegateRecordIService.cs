using Hengtex.Application.Entity.FlowManage;
using Hengtex.Util.WebControl;
using System.Data;

namespace Hengtex.Application.IService.FlowManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.01.14 11:02
    /// 描 述：工作流委托记录操作接口（支持：SqlServer）
    /// </summary>
    public interface WFDelegateRecordIService
    {
        #region 获取数据
        /// <summary>
        /// 获取分页数据(type 1：委托记录，其他：被委托记录)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <param name="type"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        DataTable GetPageList(Pagination pagination, string queryJson, int type, string userId = null);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实体数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, WFDelegateRecordEntity entity);
        #endregion
    }
}
