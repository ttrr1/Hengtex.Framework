using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-24 17:21
    /// 描 述：con_pan_head_in
    /// </summary>
    public class con_pan_head_in_detailMap : EntityTypeConfiguration<con_pan_head_in_detailEntity>
    {
        public con_pan_head_in_detailMap()
        {
            #region 表、主键
            //表
            this.ToTable("con_pan_head_in_detail");
            //主键
            this.HasKey(t => t.phid_id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
