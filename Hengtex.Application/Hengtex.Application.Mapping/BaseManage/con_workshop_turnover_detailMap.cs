using Hengtex.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-01-19 15:26
    /// 描 述：con_workshop_turnover
    /// </summary>
    public class con_workshop_turnover_detailMap : EntityTypeConfiguration<con_workshop_turnover_detailEntity>
    {
        public con_workshop_turnover_detailMap()
        {
            #region 表、主键
            //表
            this.ToTable("con_workshop_turnover_detail");
            //主键
            this.HasKey(t => t.wtd_id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
