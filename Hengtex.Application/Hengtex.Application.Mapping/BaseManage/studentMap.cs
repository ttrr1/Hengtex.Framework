using Hengtex.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2017-03-01 09:20
    /// 描 述：学生表
    /// </summary>
    public class studentMap : EntityTypeConfiguration<studentEntity>
    {
        public studentMap()
        {
            #region 表、主键
            //表
            this.ToTable("student");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
