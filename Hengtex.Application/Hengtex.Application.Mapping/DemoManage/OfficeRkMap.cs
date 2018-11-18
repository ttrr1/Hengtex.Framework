using Hengtex.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.DemoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2016-12-06 17:29
    /// 描 述：OfficeRk
    /// </summary>
    public class OfficeRkMap : EntityTypeConfiguration<OfficeRkEntity>
    {
        public OfficeRkMap()
        {
            #region 表、主键
            //表
            this.ToTable("OfficeRk");
            //主键
            this.HasKey(t => t.OrderId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
