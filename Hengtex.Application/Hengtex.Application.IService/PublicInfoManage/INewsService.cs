using Hengtex.Application.Entity.PublicInfoManage;
using Hengtex.Util.WebControl;
using System.Collections.Generic;

namespace Hengtex.Application.IService.PublicInfoManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.7 16:40
    /// 描 述：新闻中心
    /// </summary>
    public interface INewsService
    {
        #region 获取数据
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<NewsEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="topCnt">取记录数</param>
        /// <returns></returns>
        IEnumerable<NewsEntity> GetNewsListByTopCount(string topCnt);

        /// <summary>
        /// 新闻实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        NewsEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存新闻表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, NewsEntity newsEntity);
        #endregion
    }
}
