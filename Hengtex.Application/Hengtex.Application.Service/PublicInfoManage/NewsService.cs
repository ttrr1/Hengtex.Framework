using Hengtex.Application.Entity.PublicInfoManage;
using Hengtex.Application.IService.PublicInfoManage;
using Hengtex.Data.Repository;
using Hengtex.Util;
using Hengtex.Util.Extension;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Text;

namespace Hengtex.Application.Service.PublicInfoManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.7 16:40
    /// 描 述：新闻中心
    /// </summary>
    public class NewsService : RepositoryFactory<NewsEntity>, INewsService
    {
        #region 获取数据
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<NewsEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["FullHead"].IsEmpty())
            {
                string FullHead = queryParam["FullHead"].ToString();
                expression = expression.And(t => t.FullHead.Contains(FullHead));
            }
            if (!queryParam["Category"].IsEmpty())
            {
                string Category = queryParam["Category"].ToString();
                expression = expression.And(t => t.Category == Category);
            }
            expression = expression.And(t => t.TypeId == 1);
            return this.BaseRepository().FindList(expression, pagination);
        }


        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="topCnt">取记录数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetNewsListByTopCount(string topCnt)
        {
            var strSql = new StringBuilder();
            strSql.Append("SELECT  top ");
            strSql.Append(topCnt);
            strSql.Append(@" a.*
                            FROM    Base_News a
                            where DeleteMark=0 and TypeId = 2       
                            order by ReleaseTime desc   ");
     
            return this.BaseRepository().FindList(strSql.ToString());
        }
        /// <summary>
        /// 新闻实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public NewsEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存新闻表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                newsEntity.Modify(keyValue);
                newsEntity.TypeId = 1;
                this.BaseRepository().Update(newsEntity);
            }
            else
            {
                newsEntity.Create();
                newsEntity.TypeId = 1;
                this.BaseRepository().Insert(newsEntity);
            }
        }
        #endregion
    }
}
