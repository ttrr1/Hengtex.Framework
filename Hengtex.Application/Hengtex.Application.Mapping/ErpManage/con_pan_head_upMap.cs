using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-22 15:57
    /// 描 述：con_pan_head_up
    /// </summary>
    public class con_pan_head_upMap : EntityTypeConfiguration<con_pan_head_upEntity>
    {
        public con_pan_head_upMap()
        {
            #region 表、主键
            //表
            this.ToTable("con_pan_head_up");
            //主键
            this.HasKey(t => t.phu_id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
