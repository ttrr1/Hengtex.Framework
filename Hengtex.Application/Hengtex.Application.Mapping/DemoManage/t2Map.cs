using Hengtex.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.DemoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2017-02-21 09:18
    /// 描 述：测试1
    /// </summary>
    public class t2Map : EntityTypeConfiguration<t2Entity>
    {
        public t2Map()
        {
            #region 表、主键
            //表
            this.ToTable("t2");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
