using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：lvh
    /// 日 期：2018-02-10 10:17
    /// 描 述：doc_con_pan_position
    /// </summary>
    public class doc_con_pan_positionMap : EntityTypeConfiguration<doc_con_pan_positionEntity>
    {
        public doc_con_pan_positionMap()
        {
            #region 表、主键
            //表
            this.ToTable("doc_con_pan_position");
            //主键
            this.HasKey(t => t.dcpp_num);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
