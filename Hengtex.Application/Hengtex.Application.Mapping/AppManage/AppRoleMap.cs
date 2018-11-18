using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.4 14:31
    /// 描 述：角色管理
    /// </summary>
    public class AppRoleMap : EntityTypeConfiguration<AppRoleEntity>
    {
        public AppRoleMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_Role");
            //主键
            this.HasKey(t => t.RoleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
