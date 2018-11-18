using Hengtex.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.7 16:40
    /// 描 述：新闻中心
    /// </summary>
    public class NewsMap : EntityTypeConfiguration<NewsEntity>
    {
        public NewsMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_News");
            //主键
            this.HasKey(t => t.NewsId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
