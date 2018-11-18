using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class AppModuleMap : EntityTypeConfiguration<AppModuleEntity>
    {
        public AppModuleMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_Module");
            //主键
            this.HasKey(t => t.ModuleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
