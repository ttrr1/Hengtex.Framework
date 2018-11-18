using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户关系
    /// </summary>
    public class AppUserRelationMap : EntityTypeConfiguration<AppUserRelationEntity>
    {
        public AppUserRelationMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_UserRelation");
            //主键
            this.HasKey(t => t.UserRelationId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
