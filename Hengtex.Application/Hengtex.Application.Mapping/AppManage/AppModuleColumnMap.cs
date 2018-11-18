using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class AppModuleColumnMap : EntityTypeConfiguration<AppModuleColumnEntity>
    {
        public AppModuleColumnMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_ModuleColumn");
            //主键
            this.HasKey(t => t.ModuleColumnId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
