using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-02-05 18:06
    /// 描 述：doc_con_pan_head
    /// </summary>
    public class doc_con_pan_headMap : EntityTypeConfiguration<doc_con_pan_headEntity>
    {
        public doc_con_pan_headMap()
        {
            #region 表、主键
            //表
            this.ToTable("doc_con_pan_head");
            //主键
            this.HasKey(t => t.dcph_num);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
