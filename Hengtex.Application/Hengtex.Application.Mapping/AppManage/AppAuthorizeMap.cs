using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.27
    /// 描 述：授权功能
    /// </summary>
    public class AppAuthorizeMap : EntityTypeConfiguration<AppAuthorizeEntity>
    {
        public AppAuthorizeMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_Authorize");
            //主键
            this.HasKey(t => t.AuthorizeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
