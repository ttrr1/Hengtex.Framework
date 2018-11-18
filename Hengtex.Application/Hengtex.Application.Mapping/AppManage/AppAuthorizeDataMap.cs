using Hengtex.Application.Entity.AppManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.27
    /// 描 述：授权数据范围
    /// </summary>
    public class AppAuthorizeDataMap : EntityTypeConfiguration<AppAuthorizeDataEntity>
    {
        public AppAuthorizeDataMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_AuthorizeData");
            //主键
            this.HasKey(t => t.AuthorizeDataId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
