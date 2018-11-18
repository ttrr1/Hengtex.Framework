using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.02 14:27
    /// 描 述：部门管理
    /// </summary>
    public class AppDepartmentMap : EntityTypeConfiguration<AppDepartmentEntity>
    {
        public AppDepartmentMap()
        {
            #region 表、主键
            //表
            this.ToTable("sys_Departments");
            //主键
            this.HasKey(t => t.DepartNo);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
