using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    public class AppModuleButtonMap : EntityTypeConfiguration<AppModuleButtonEntity>
    {
        public AppModuleButtonMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_ModuleButton");
            //主键
            this.HasKey(t => t.ModuleButtonId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
