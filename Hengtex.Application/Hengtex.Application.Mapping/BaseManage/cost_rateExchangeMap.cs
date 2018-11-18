using Hengtex.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-01-19 14:56
    /// 描 述：cost_rateExchange
    /// </summary>
    public class cost_rateExchangeMap : EntityTypeConfiguration<cost_rateExchangeEntity>
    {
        public cost_rateExchangeMap()
        {
            #region 表、主键
            //表
            this.ToTable("cost_rateExchange");
            //主键
            this.HasKey(t => t.re_id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
