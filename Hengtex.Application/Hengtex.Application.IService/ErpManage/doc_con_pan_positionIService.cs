using Hengtex.Application.Entity.ErpManage;
using Hengtex.Util.WebControl;
using System.Collections.Generic;

namespace Hengtex.Application.IService.ErpManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：lvh
    /// 日 期：2018-02-10 10:17
    /// 描 述：doc_con_pan_position
    /// </summary>
    public interface doc_con_pan_positionIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<doc_con_pan_positionEntity> GetList(string fieldName,string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        doc_con_pan_positionEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, doc_con_pan_positionEntity entity);
        #endregion
    }
}
